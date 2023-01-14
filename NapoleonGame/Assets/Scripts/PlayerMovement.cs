using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public GameObject SoldierSender;

    public GameObject boat;
    public GameObject collObj;

    public GameObject GeorgeIII;

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
        //kada se pritisne space i dodiruje pod(može sko?iti)
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            //sko?i,pokreni animaciju skoka
            animator.SetBool("Jumping", true);
            canJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    //Kodovi za CollisionEnter2D metodu

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collObj = collision.gameObject;
        //kada dodiruje pod tada može skociti
        animator.SetBool("Jumping", false);
        if (collObj.tag == "ground")
        {
            canJump = true;

        }
        if (collObj.name == "BoatWall")
        {
            boat.GetComponent<Animator>().SetBool("InBoat", true);
        }
        if (collObj.tag == "SoldierBody")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collObj.tag == "SoldierHead")
        {
            Destroy(collObj.transform.parent.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collObj = collision.gameObject;
        if (collision.gameObject.name == "Logs")
        {
            collision.gameObject.SetActive(false);
            boat.SetActive(true);
        }
    }


}
