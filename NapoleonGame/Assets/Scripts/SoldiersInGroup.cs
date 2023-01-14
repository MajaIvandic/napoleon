using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersInGroup : MonoBehaviour
{
    public GameObject Group;
    public GameObject NewGroup;
    public GameObject player;
    public GameObject George;

    private float x;

    Rigidbody2D rb;
    private void Start()
    {
        rb = Group.GetComponent<Rigidbody2D>();
        x = Group.transform.position.x;
}
    private void Update()
    {
        if(George.GetComponent<GeorgeIII>().StopSoldiers == true)
        {
            Destroy(Group);
        }
        if (CompareTag("SoldierGroup"))
        {
            rb.velocity = new Vector2(-3f, rb.velocity.y);
        }
        /*if (player.GetComponent<Hearts>().IsDead == true)
        {
            Group.transform.position = new Vector2(x, 16.81f);
        }*/
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (name == "LastSoldier")
        {
            if (collision.gameObject.name == "NewGroupWall")
            {
                NewGroup.SetActive(true);
            }
             if (collision.gameObject.name == "TpWall")
            {
                Group.transform.position = new Vector2(-72, 16.81f);
            }
        }
    }
}
