using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNapoleon : MonoBehaviour
{
    float speed = 3.5f;
    bool flipped = false;
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Walk();
    }
    void Walk()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name =="Wall2")
        {
            Flip();
            flipped = true;
        }
        else if(collision.gameObject.name =="Wall1")
        {
            speed = 3.5f;
            Flip();
            flipped=false;
        }
        if(collision.gameObject.CompareTag("ground"))
        {
            GetComponent<Animator>().SetBool("Jump",false);
        }
    }

    void Flip()
    {
        if (flipped == true)
        {
            flipped= false;
            sr.flipX = false;
        }
        else
        {
            flipped = true;
            sr.flipX = true;
            speed = -3.5f;
        }
    }
}
