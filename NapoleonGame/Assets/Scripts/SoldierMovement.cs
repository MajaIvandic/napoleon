using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoldierMovement : MonoBehaviour
{   
    public GameObject Hearts;
    public GameObject Cannonball;
    private GameObject collObj;
    public GameObject NewCannonBall;

    public bool flippedRight;

    public bool flippedLeft;

    Rigidbody2D rb;

    void Update()
    {
        Walk();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        collObj = collision.gameObject;
        if (collObj.name == "Player" && name == "SoldierSender")
        {
            Hearts.SetActive(true);
            rb = collObj.GetComponent<Rigidbody2D>();
            collObj.transform.position = new Vector2(-167.6f, 18.2f);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(Wait());
        }

        if(collObj.name == "CannonWall" && Cannonball)
        {
            transform.position = new Vector2(57, 16.99f);
        }
        if(collObj.name == "NewBallWall" && Cannonball)
        {
            NewCannonBall.SetActive(true);
        }
        if (collObj.name == "Player" && Cannonball)
        {
            collObj.transform.position = new Vector2(88.73f, 20.27f);
        }

        if (collObj.name == "Wall1" && name != "CannonBall")
        {
            flippedRight = true;
            flippedLeft = false;
        }
        else if (collObj.name == "Wall2" && name != "CannonBall")
        {
            flippedLeft = true;
            flippedRight = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        collObj.GetComponent<SpriteRenderer>().flipX = false;
    }

    void Walk()
    {
        if(Cannonball)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(5f, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(3, GetComponent<Rigidbody2D>().velocity.y);
        }
        Flip();
    }

    public void Flip()
    {
        if (flippedLeft == true)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (flippedRight == true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-3,GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
