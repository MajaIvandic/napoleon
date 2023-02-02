using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagScript : MonoBehaviour
{
    public GameObject Flag;
    public GameObject Player;
    public bool TouchedFlag = false;

    void Update()
    {
        if (TouchedFlag == true)
        {
            Flag.transform.SetParent(Player.transform);
            Flag.transform.position = Player.transform.position;
            FlipFlag();
        }
  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            TouchedFlag = true;
        }

    }

    public void FlipFlag()
    {
        if (Player.GetComponent<SpriteRenderer>().flipX == true)
        {
            Flag.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            Flag.GetComponent <SpriteRenderer>().flipX = false;
        }

    }

}
