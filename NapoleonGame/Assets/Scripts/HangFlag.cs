using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangFlag : MonoBehaviour
{
    Animator animator;

    public GameObject Flag;
    public GameObject Player;
    public GameObject HangingFlag;
    public GameObject SoldierSender;

    Rigidbody2D rb;

    void Start()
    {
        animator = HangingFlag.GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player && Player.transform.Find("Flag"))
        {
            HangingFlag.transform.position = new Vector2(-28.1f, 16.65f);
            animator.SetBool("Hanging", true);
            Destroy(Flag);

            Player.GetComponent<PlayerMovement>().enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Player.GetComponent<Animator>().SetBool("Walking", false);

            StartCoroutine(Wait());
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.7f);
        SoldierSender.SetActive(true);
        SoldierSender.GetComponent<SoldierMovement>().enabled = true;
    }

    void Wave()
    {
            animator.SetBool("Waving", true);
    }
}
