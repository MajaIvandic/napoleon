using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneText : MonoBehaviour
{
    public TextMeshProUGUI Text;

    public GameObject End;

    public List<string> text = new List<string>();
    public float time = 6;
    public bool useEvent = true;
    int index = 0;

    IEnumerator TextInformations()
    {
        yield return new WaitForSeconds(2);
        while (index < text.Count)
        {
            Text.text = text[index];
            yield return new WaitForSeconds(time);
			index++;
		}

        if(index >= text.Count)
        {
            yield return new WaitForSeconds(1);
            OnEnterEvent();
        }

	}

    public void OnEnterEvent()
    {
        if (useEvent == true)
        {
            if(End != null)
            {
                End.SetActive(true);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


	private void Start()
    {
        StartCoroutine(TextInformations());
    }
}
