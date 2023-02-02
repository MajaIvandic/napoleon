using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject textObj;
    private GameObject collObj;
    public GameObject player;
    public GameObject Wellington;
    public GameObject Sounds;

    public char ch;

    AudioSource Mumbling;

    private void Start()
    {
        Mumbling = Sounds.transform.Find("NapoleonTalk").GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collObj = collision.gameObject;
        if (collObj == player)
        {   
            if(CompareTag("Key"))
            {
                GetComponent<AudioSource>().Play();
            }
            if (name == "Blue key")
            {
                Mumbling.Play();
                text.text = "Marija Lujza je rodila mog jedinog sina - Napoleona II.";
            }
            else if (name == "White key")
            {
                Mumbling.Play();
                text.text = $"Moja najve{ch}a ljubav je \n moja prva žena Jozefina.";
            }
            else if(name =="Red key")
            {
                Mumbling.Play();
                text.text = "Moja prva žena Jozefina je umrla dok sam ja ovdje na Elbi.";
            }
            else if (name == "Photo")
            {
                Mumbling.Play();
                text.text = "Ovo je moja druga supruga Marija Lujza.";
            }
            else if(name == "GuideTrigger")
            {
                text.text = $"Sko{ch}i britanskim vojnicima na glavu";
            }
            else if(name == "GuideTrigger2")
            {
                text.text = "Pazi da te vojnici ne dotaknu!";
            }
            textObj.SetActive(true);
            StartCoroutine(Wait());

            Destroy(this.GetComponent<BoxCollider2D>());
            text.enabled = true;
            textObj.SetActive(true);
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        textObj.SetActive(false);
    }
}
