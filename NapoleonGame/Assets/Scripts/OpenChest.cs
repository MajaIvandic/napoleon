using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private GameObject collObj;

    public GameObject Chest;
    public GameObject Axe;

    public GameObject blueLock;
    public GameObject whiteLock;
    public GameObject redLock;

    public GameObject blueKey;
    public GameObject whiteKey;
    public GameObject redKey;

    public GameObject Sounds;

    Animator animator;

    private void Start()
    {
        animator = Chest.GetComponent<Animator>();
    }
    private void Update()
    {
        openChest();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collObj = collision.gameObject;

        //ako igra? ima klju? neke boje otvori bravu te boje
        if(collObj.transform.Find("Blue key"))
        {
            Sounds.transform.Find("UnlockLock").GetComponent<AudioSource>().Play();
            Destroy(blueLock);
            Destroy(blueKey);
        }
        if (collObj.transform.Find("White key"))
        {
            Sounds.transform.Find("UnlockLock").GetComponent<AudioSource>().Play();
            Destroy(whiteLock);
            Destroy(whiteKey);
        }
        if (collObj.transform.Find("Red key"))
        {
            Sounds.transform.Find("UnlockLock").GetComponent<AudioSource>().Play();
            Destroy(redLock);
            Destroy(redKey);
        }

    }
    void openChest()
    {
        //ako sanduk nema više brava..
        if (!blueLock && !whiteLock && !redLock)
        {
            //otvori sanduk, prikaži sjekiru
            GetComponent<AudioSource>().Play();
            animator.SetBool("Opened", true);
            Axe.GetComponent<SpriteRenderer>().enabled = true;
            Axe.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(this.GetComponent<OpenChest>());
        }
    }
}
