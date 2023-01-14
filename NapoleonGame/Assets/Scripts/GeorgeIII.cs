using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeorgeIII : MonoBehaviour
{
    public GameObject George;
    public GameObject Player;
    public GameObject SecretWall;
    public GameObject SoldierGroup;
    public GameObject SoldierCatcher;

    public TextMeshProUGUI NapoleonText;
    public TextMeshProUGUI GeorgeText;
    public Image scroll; 

    private bool GeorgeWalk;
    public bool StopSoldiers;

    Rigidbody2D GeorgeRb;
    Rigidbody2D PlayerRb;

    Animator GeorgeAnim;

    private void Start()
    {
        GeorgeRb = George.GetComponent<Rigidbody2D>();
        GeorgeAnim = George.GetComponent<Animator>();

        PlayerRb = Player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Player.transform.position.x == -167.6f)
        {
            if (George.transform.position.x < -154)
            {
                StartCoroutine(WaitForWalk());
                GeorgeWalk = true;
            }
            else
            {
                George.transform.position = new Vector2(-83, 15.82f);
                GeorgeWalk = false;

                Player.GetComponent<PlayerMovement>().enabled = true;
                SoldierGroup.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
            Player.GetComponent<PlayerMovement>().enabled = false;
            PlayerRb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Player.GetComponent<Animator>().SetBool("Walking", false);
            StopSoldiers = true;
            StartCoroutine(CatchNapoleon());
        }
    }
    void MoveGeorge()
    {
        if(GeorgeWalk == true)
        { 
            George.GetComponent<SpriteRenderer>().flipX = false;
            GeorgeRb.velocity = new Vector2(3, GeorgeRb.velocity.y);
            GeorgeAnim.SetBool("Walking", true);
        }
        else
        {
            GeorgeAnim.SetBool("Walking", false);
            GeorgeRb.constraints = RigidbodyConstraints2D.FreezePosition;
            George.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    IEnumerator WaitForWalk()
    {
        yield return new WaitForSeconds(2);
        MoveGeorge();
    }
    IEnumerator CatchNapoleon()
    {
        yield return new WaitForSeconds(4);
        SoldierCatcher.SetActive(true);
    }
}
