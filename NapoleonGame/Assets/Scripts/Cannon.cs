using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject Cannonball;
    public GameObject NewCannonBall;

    GameObject collObj;

    private void Update()
    {
        Walk();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collObj = collision.gameObject;
        if (collObj.name == "Player")
        {
            collObj.transform.position = new Vector2(88.73f, 20.27f);
        }
        if (collObj.name == "CannonWall")
        {
            Cannonball.transform.position = new Vector2(57, 16.99f);
        }
        if (collObj.name == "NewBallWall")
        {
            NewCannonBall.SetActive(true);
        }
    }

    void Walk()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(5f, GetComponent<Rigidbody2D>().velocity.y);
    }

}
