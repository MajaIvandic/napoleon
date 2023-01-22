using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Book : MonoBehaviour
{
    //Deklariranje

    public List<string> text = new List<string>();
    int index = 0;

    public GameObject Player;
    public TextMeshProUGUI Text;

    Animator animator;

    //Start
    void Start()
    {
        //Deklariranje animatora
        animator = Player.GetComponent<Animator>();
    }

    //OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ako knjiga dotakne igraca...
        if (collision.gameObject == Player)
        {
            index = 2;
            Text.text = text[index];
            Text.transform.parent.parent.gameObject.SetActive(true);
            Player.GetComponent<PlayerMovement>().enabled = false;
            animator.SetBool("Walking", false);
            StartCoroutine(WaitBeforeNextScene());
        }
    }


    //OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            index = 1;
            Text.text = text[index];
            Text.transform.parent.parent.gameObject.SetActive(true);
            Player.GetComponent<PlayerMovement>().enabled = false;
            animator.SetBool("Walking", false);
            StartCoroutine(WaitBeforeWalking());
        }
    }

    //IEnumerator WaitBeforeWalking
    IEnumerator WaitBeforeWalking()
    {
        //Cekaj 4 sekunde, pokreni igraca
        yield return new WaitForSeconds(4);
        Player.GetComponent<PlayerMovement>().enabled = true;
        Text.transform.parent.parent.gameObject.SetActive(false);
        transform.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    //IEnumerator WaitBeforeNextScene
    IEnumerator WaitBeforeNextScene()
    {
        //Cekaj 4 sekunde, pokreni sljedecu scenu
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




}
