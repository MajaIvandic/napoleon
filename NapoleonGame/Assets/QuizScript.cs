using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Data.Common;
using System;

public class QuizScript : MonoBehaviour
{
    public string question;
    public string[] answers;
    public int correntAnswer;

    int AnswersIndex = 4;

	[Space]
	[Space]
	public TextMeshProUGUI _questionText;
    public GameObject _btnAnswer;
    public GameObject _parentQuestions;

    void Start()
    {
        DisplayQuestions();
    }


    private void DisplayQuestions()
    {
        _questionText.text = question;

        for (int i = 0; i < AnswersIndex; i++)
        {
           
			GameObject go = Instantiate(_btnAnswer, Vector3.zero, Quaternion.identity);
			go.transform.parent = _parentQuestions.transform;
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = answers[i];

            go.name = i.ToString();
            go.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(Int32.Parse(go.name)));
		}

    }


	private void CheckAnswer(int answer)
	{
		if(answer == correntAnswer)
        {
            Debug.Log("Odgovor je ispravan!");
        }
        else
        {
            Debug.Log("Odgovor je pogrešan!");
        }
        AnswersIndex += 4;
	}
}
