using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public GameObject SoldierSender;
    public GameObject Questions;

    public GameObject boat;
    public GameObject collObj;

    float inputHorizontal;

    public float speed = 6.5f;
    public float jumpForce = 30f;

    private bool canJump;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Walk();
        Jump();
    }
    void Walk()
    {
        //kad se pritisnu tipke za hodanje..
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        //kreci se naprijed
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

        //ako se krece desno okreni ga desno
        if (inputHorizontal > 0 && spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX = false;
        }
        //ako se krece lijevo okreni ga lijevo
        else if (inputHorizontal < 0 && spriteRenderer.flipX == false)
        {
            spriteRenderer.flipX= true;
        }
        //ako hoda pokreni animaciju hodanja
        if (inputHorizontal != 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void Jump()
    {
        //kada se pritisne space i dodiruje pod(može skociti)
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            //skoci,pokreni animaciju skoka
            animator.SetBool("Jumping", true);
            canJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    //Kodovi za CollisionEnter2D metodu

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collObj = collision.gameObject;
        if (collObj.name == "SoldierCatcher")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collObj.name == "Logs")
        {
            collObj.SetActive(false);
            boat.SetActive(true);
        }
        if(collObj.name == "Book")
        {
            Questions.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (collObj.tag == "SoldierHead")
        {
            Debug.Log("head");
            Destroy(collObj.transform.parent.gameObject);
        }
        else if (collObj.tag == "SoldierBody")
        {
            Debug.Log("body");
            collObj.GetComponentInParent<SoldierMovement>().KillPlayer();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collObj = collision.gameObject;
        if (collObj.CompareTag("ground"))
        {
            canJump = true;
            animator.SetBool("Jumping", false);
        }
    }
}
