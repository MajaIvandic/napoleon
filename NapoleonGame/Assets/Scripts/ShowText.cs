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

    public char SoftCh;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collObj = collision.gameObject;
        if (collObj == player)
        {
            if (name == "Blue key")
            {
                text.text = "Marija Lujza je rodila mog jedinog sina - Napoleona II.";
            }
            else if (name == "Photo")
            {
                text.text = "Ovo je moja druga supruga Marija Lujza.";
            }
            else if (name == "White key")
            {
                text.text = $"Moja najve{SoftCh}a ljubav je \n moja prva žena Jozefina.";
            }
            else if(name =="Red key")
            {
                text.text = "Moja prva žena Jozefina je umrla dok sam ja ovdje na Elbi.";
            }
        }

        Destroy(this.GetComponent<BoxCollider2D>());
        text.enabled = true;
        textObj.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        textObj.SetActive(false);
    }
}
