using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Data.Common;
using System;
using UnityEngine.EventSystems;

public class QuizScript : MonoBehaviour
{
    public string question;
    public string[] answers;
    public int correctAnswer;
    public char ch;
    bool takePoints = true;
    int points = 10;

    [Space]
    [Space]
    public TextMeshProUGUI _questionText;

    public GameObject _btnAnswer;
    public GameObject _parentQuestions;
    public GameObject _NextQuestion;
    public GameObject questionObject;
    public GameObject pointShow;

    void Start()
    {
        DisplayQuestions();
    }

    private void DisplayQuestions()
    {
        _questionText.text = question;

        for (int i = 0; i < answers.Length; i++)
        {
            GameObject go = Instantiate(_btnAnswer, Vector3.zero, Quaternion.identity);
            go.transform.parent = _parentQuestions.transform;
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = answers[i];
            go.name = i.ToString();
            go.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(Int32.Parse(go.name))) ;
            go.GetComponent<Button>().onClick.AddListener(() => ChangeColors(go.GetComponent<Button>()));
        }
    }
    private void CheckAnswer(int answer)
    {
        if (_NextQuestion == null)
        {
            StartCoroutine(QuizOver());
        }
        if (answer == correctAnswer)
        {
                StartCoroutine(NextQuestion());
                takePoints = false;

        }
        else
        {
            if (this != questionObject && takePoints == true)
            {
                takePoints = false;
                questionObject.GetComponent<QuizScript>().points--;
                Debug.Log(questionObject.GetComponent<QuizScript>().points);
                StartCoroutine(NextQuestion());
            }
        }
    }

    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(1.2f);
        takePoints = true;
        _NextQuestion.SetActive(true);
        gameObject.SetActive(false);
    }

    IEnumerator QuizOver()
    {
        yield return new WaitForSeconds(2);
        TextMeshProUGUI comment = pointShow.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        pointShow.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = $"{questionObject.GetComponent<QuizScript>().points}/10";
        if(questionObject.GetComponent<QuizScript>().points >= 8)
        {
           comment.text = $"Bravo! Odli{ch}no poznaješ Napoleona!";
        }
        else if(questionObject.GetComponent<QuizScript>().points >= 5)
        {
            comment.text = "Dobro poznaješ Napoleona!";
        }
        else if(questionObject.GetComponent<QuizScript>().points < 5)
        {
            comment.text = "O ne! Ne poznaješ dobro Napoleona!";
        }
        pointShow.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChangeColors(Button button)
    {
        if (button.gameObject.name == correctAnswer.ToString())
        {
            button.GetComponent<Image>().color = Color.green;
        }
        else
        {
            button.GetComponent<Image>().color = Color.red;
            button.gameObject.transform.parent.GetChild(correctAnswer).gameObject.GetComponent<Image>().color = Color.green;
        }
    }
}
