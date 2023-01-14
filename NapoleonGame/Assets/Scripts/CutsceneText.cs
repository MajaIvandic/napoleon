using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneText : MonoBehaviour
{
    public TextMeshProUGUI LeavingText;

    public List<string> text = new List<string>();
    public int time = 3;
    public bool useEvent = true;
    int index = 0;

    IEnumerator TextInformations()
    {
        while (index < text.Count)
        {
			yield return new WaitForSeconds(time);
			LeavingText.text = text[index];
			index++;
		}

        if(index >= text.Count)
        {
            OnEnterEvent();
        }

	}

    private void OnEnterEvent()
    {
        if (useEvent == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


	private void Start()
    {
        StartCoroutine(TextInformations());
    }
}
