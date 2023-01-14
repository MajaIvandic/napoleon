using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public GameObject player;

    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    int Lifes = 3;
    public bool IsDead;
    private void Update()
    {
        LifeDown();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GeorgeSoldier")
        {
            Lifes --;
        }
    }

    void LifeDown()
    {
        if(Lifes==3)
        {
            IsDead = false;
            Heart1.enabled = true;
            Heart2.enabled = true;
            Heart3.enabled = true;
        }
        else if(Lifes==2)
        {
            Heart1.enabled = false;
        }
        else if(Lifes==1)
        {
            Heart2.enabled = false;
        }
        else if (Lifes==0)
        {
            SoldierSpawner.instante.DestryAll();
            player.transform.position = new Vector2(-170.44f, 15.699f);
            Lifes = 3;
            IsDead = true;
        }
    }
}
