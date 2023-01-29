using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject MainButtons;
    public GameObject controls;
    public GameObject Loading;
    public GameObject Napoleon;
    public void StartLoading()
    {
        MainButtons.SetActive(false);
        Loading.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        if(controls.active == true)
        {
            MainButtons.SetActive(true);
            controls.SetActive(false);
        }
        else
        {
            MainButtons.SetActive(false);
            controls.SetActive(true);
        }
    }

    public void NapoleonJump()
    {
        if (Napoleon.transform.position.y < -.33f)
        {
            Rigidbody2D rb = Napoleon.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 4);
            Napoleon.GetComponent<Animator>().SetBool("Jump", true);
        }
    }

    public void StartQuiz()    
    {
        gameObject.SetActive(false);
        transform.parent.parent.GetChild(1).gameObject.SetActive(true);
    }
}
