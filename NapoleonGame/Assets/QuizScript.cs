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


	[Space]
	[Space]
	public TextMeshProUGUI _questionText;
    public GameObject _btnAnswer;
    public GameObject _parentQuestions;
    public GameObject _NextQuestion;

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
            go.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(Int32.Parse(go.name)));
		}

    }


	private void CheckAnswer(int answer)
	{
		if(answer == correntAnswer)
        {
            if (_NextQuestion == null)
            {
                Debug.Log("Kviz gotov.");
            }
            else
            {
                _NextQuestion.SetActive(true);
                gameObject.SetActive(false);
            }
        }
	}
}
