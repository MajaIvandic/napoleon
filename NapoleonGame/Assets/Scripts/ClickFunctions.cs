using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickFunctions : MonoBehaviour
{
    public GameObject player;
    private GameObject collObj;

    //kada dodirne neki predmet..
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collObj = collision.gameObject;

        //ako predmet ima tag "Door" pokreni funkciju
        if (collObj.tag == "Door")
        {
            openDoor();
        }

        //ako predmet ima tag "Key" pokreni funkcije
        if (collObj.tag == "Key")
        {
            //namjesti klju? na igra?a
            collObj.transform.SetParent(player.transform);
            collObj.transform.eulerAngles = new Vector3(0, 0, -88.017f);

            keySize();
        }

        //ako se predmet zove "Axe" namjesti sjekiru na igracsa
        if (collObj.name == "Axe")
        {
            collObj.transform.SetParent(player.transform);
            collObj.transform.position = new Vector3(player.transform.position.x - .33f, player.transform.position.y - .6f);
            collObj.GetComponent<SpriteRenderer>().sortingOrder = 3;
            collObj.transform.eulerAngles = new Vector3(0, 0, 29.86f);
        }
        
    }
    void keySize()
    {
        //namještavanje pozicije svakog kljuca na igraca
        if (collObj.name == "Blue key")
        {
            collObj.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 1.1f);
        }
        else if (collObj.name == "White key")
        {
            collObj.transform.position = new Vector2(player.transform.position.x + .33f, player.transform.position.y - 1.1f);
        }
        else if (collObj.name == "Red key")
        {
            collObj.transform.position = new Vector2(player.transform.position.x + .66f, player.transform.position.y - 1.1f);
        }
    }
    void openDoor()
    {
        //oznacavanje pozicije gdje ce se igrac pojaviti kad prode kroz vrata
        if (player.transform.position.x > -35f)
        {
            player.transform.position = new Vector3(-58, -2.69f, 0);
        }
        else
        {
            player.transform.position = new Vector3(-23.6f, -2.6f, 0);
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
