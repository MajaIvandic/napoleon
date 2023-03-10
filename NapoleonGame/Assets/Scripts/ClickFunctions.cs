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
        if (collObj.CompareTag("Door"))
        {
            OpenDoor();
        }

        //ako predmet ima tag "Key" pokreni funkcije
        if (collObj.CompareTag("Key"))
        {
            //namjesti kljuc na igraca
            collObj.transform.SetParent(player.transform);
            collObj.transform.eulerAngles = new Vector3(0, 0, -88.017f);

            KeySize();
        }

        //ako se predmet zove "Axe" namjesti sjekiru na igracsa
        if (collObj.name == "Axe")
        {
            collObj.GetComponent<AudioSource>().Play();
            collObj.transform.SetParent(player.transform);
            collObj.transform.position = new Vector3(player.transform.position.x - .33f, player.transform.position.y - .6f);
            collObj.GetComponent<SpriteRenderer>().sortingOrder = 3;
            collObj.transform.eulerAngles = new Vector3(0, 0, 29.86f);
        }
        
    }
    void KeySize()
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
    void OpenDoor()
    {
        //oznacavanje pozicije gdje ce se igrac pojaviti kad prode kroz vrata
        if (player.transform.position.x > -35f)
        {
            player.transform.position = new Vector3(-58, -2.69f, 0);
        }
        else
        {
            player.transform.position = new Vector3(-22.21f, -2.6f, 0);
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
