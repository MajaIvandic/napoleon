using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoldierMovement : MonoBehaviour
{   
    private GameObject collObj;

    public GameObject Hearts;
    public GameObject SoldierGroup;
    public GameObject Spawn;
    public GameObject Player;

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
            SoldierGroup.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(Wait());
        }
        if (collObj.name == "Wall1")
        {
            flippedRight = true;
            flippedLeft = false;
        }
        else if (collObj.name == "Wall2")
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
        GetComponent<Rigidbody2D>().velocity = new Vector2(3, GetComponent<Rigidbody2D>().velocity.y);
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

    public void KillPlayer()
    {
        Player.transform.position = new Vector2(Spawn.transform.position.x,Spawn.transform.position.y);
        Debug.Log("Soldiered");
    }
}
