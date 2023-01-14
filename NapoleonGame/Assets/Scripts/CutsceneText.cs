using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneText : MonoBehaviour
{
    public TextMeshProUGUI LeavingText;
    public TextMeshProUGUI IntroText;

    public char ch;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Cutscene1-2")
        {
            StartCoroutine(Leaving());
        }
        else
        {
            StartCoroutine(Intro());
        }
    }

    IEnumerator Leaving()
    {
        yield return new WaitForSeconds(2);
        LeavingText.text = "Napoleon je na otoku bio 300 dana.";
        yield return new WaitForSeconds(6);
        LeavingText.text = $"Vratio se u Pariz 26. velja{ch}e 1815. godine.";
        yield return new WaitForSeconds(6);
        LeavingText.text = $"Tako je po{ch}ela vladavina sto dana.";
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(2);
        IntroText.text = "1814. godine Napoleon je prisiljen abdicirati te je izgnan na talijanski otok Elbu.";
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
