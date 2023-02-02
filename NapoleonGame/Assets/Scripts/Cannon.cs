using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject Cannonball;
    public GameObject NewCannonBall;
    public GameObject Sounds;

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
            Sounds.transform.Find("Hurt").GetComponent<AudioSource>().Play();
            collObj.transform.position = new Vector2(88.73f, 20.27f);
        }
        if (collObj.name == "CannonWall")
        {
            transform.parent.parent.Find("TheCannon").GetComponent<AudioSource>().Play();
            transform.parent.parent.Find("TheCannon").GetComponent<AudioSource>().pitch = (Random.Range(1,2));
            Cannonball.transform.position = new Vector2(57, Cannonball.transform.position.y);
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
