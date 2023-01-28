using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject MainButtons;
    public GameObject controls;
    public GameObject Loading;
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
}
