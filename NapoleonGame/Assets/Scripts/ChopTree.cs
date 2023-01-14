
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChopTree : MonoBehaviour
{
    public GameObject player;
    public GameObject axe;
    public GameObject Logs;
    public GameObject chopping;

    public Image breaking1;
    public Image breaking2;

    Rigidbody2D rb;

    private void Update()
    {
        chopTree();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ako igrac ima sjekiru prika�i mini igru
        if(collision.gameObject == player)
        {
            if(player.transform.Find("Axe"))
            {
                chopping.SetActive(true);
                Destroy(axe);
            }
        }
    }
    void chopTree()
    {
        rb = player.GetComponent<Rigidbody2D>();
        if (chopping.active == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            player.GetComponent<PlayerMovement>().enabled = false;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(breaking1.enabled == true)
                {
                    breaking2.enabled = true;
                    breaking1.enabled = false;
                }
                else if(breaking2.enabled == true)
                {
                    chopped();
                }
                else
                {
                    breaking1.enabled = true;
                }
            }
        }        
    }

    void chopped()
    {
        chopping.SetActive(false);
        this.GetComponent<SpriteRenderer>().enabled = false;
        Logs.SetActive(true);

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
