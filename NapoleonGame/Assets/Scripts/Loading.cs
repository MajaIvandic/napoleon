using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Slider slider;

    float progress;

    public TextMeshProUGUI loadingText;
    public TextMeshProUGUI percentage;

    public char ch;

    public void Load()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        StartCoroutine(LoadText());
        while (slider.value < slider.maxValue)
        {
            yield return new WaitForSeconds(.055f);
            progress ++;
            slider.value= progress;
            percentage.text = $"{progress}%";
            if(progress == slider.maxValue)
            {
                StartCoroutine(StartGame());
                break;
            }
        }
    }

    IEnumerator LoadText()
    {
        while (slider.value < slider.maxValue)
        {
            loadingText.text = $"U{ch}itavanje.";
            yield return new WaitForSeconds(.5f);
            loadingText.text = $"U{ch}itavanje..";
            yield return new WaitForSeconds(.5f);
            loadingText.text = $"U{ch}itavanje...";
            yield return new WaitForSeconds(.5f);
        }

    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
