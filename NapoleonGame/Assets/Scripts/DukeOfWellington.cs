using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DukeOfWellington : MonoBehaviour
{
    public GameObject Wellington;
    public GameObject Player;
    public GameObject SecretWall;

    public GameObject SoldierCatcher;

    private bool WellingtonWalk;
    bool napoleonturn;
    bool End;
    public bool StopSoldiers;
    public string dialogue;
    public char ch;



    Rigidbody2D WellingtonRb;
    Rigidbody2D PlayerRb;

    public TextMeshProUGUI WellingtonText;
    public TextMeshProUGUI NapoleonText;

    Animator WellingtonAnim;

    public List<string> text = new List<string>();

    private void Start()
    {
        WellingtonRb = Wellington.GetComponent<Rigidbody2D>();
        WellingtonAnim = Wellington.GetComponent<Animator>();

        PlayerRb = Player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        NapoleonText.text = dialogue;
        WellingtonText.text = dialogue;
        if (Player.transform.position.x == -167.6f)
        {
            if (Player.transform.position.y == 18.2f)
            {
                Dialogues();
            }
            if (Wellington.transform.position.x < -154)
            {
                WellingtonWalk = true;
            }
            else
            {
                Wellington.transform.position = new Vector2(-83, Wellington.transform.position.y);
                MoveWellington();
                WellingtonWalk = false;

                Player.GetComponent<PlayerMovement>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
			SoldierSpawner.instante.DestroyAll();
			Destroy(SoldierSpawner.instante);
			Player.GetComponent<PlayerMovement>().enabled = false;
            PlayerRb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Player.GetComponent<Animator>().SetBool("Walking", false);
            StopSoldiers = true;
            End = true;
        }
    }
    void MoveWellington()
    {
        if(WellingtonWalk == true)
        { 
            Wellington.GetComponent<SpriteRenderer>().flipX = false;
            WellingtonRb.velocity = new Vector2(3, WellingtonRb.velocity.y);
            WellingtonAnim.SetBool("Walking", true);
        }
        else
        {
            WellingtonAnim.SetBool("Walking", false);
            WellingtonRb.constraints = RigidbodyConstraints2D.FreezePosition;
            Wellington.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    IEnumerator Texts()
    {
            yield return new WaitForSeconds(2);
            dialogue = "O, ne! To je moj neprijatelj, britanski general Wellington!";
            napoleonturn = true;
            Turns();

            yield return new WaitForSeconds(5);
            dialogue = $"Ako se želiš boriti sa mnom, moraš pro{ch}i moje vojnike!";
            napoleonturn = false;
            Turns();

            yield return new WaitForSeconds(5);
            WellingtonText.transform.parent.gameObject.SetActive(false);
            MoveWellington();


            yield return new WaitUntil(() => End == true);


            yield return new WaitForSeconds(1);
            dialogue = "Ha! Vojnici su ti jadni!"; 
            napoleonturn = true;
            Turns();

            yield return new WaitForSeconds(3);
            dialogue = "Ha! Zaboravio si na jednoga!";
            napoleonturn = false;
            Turns();

            yield return new WaitForSeconds(2.5f);
            SoldierCatcher.SetActive(true);
            

        yield return new WaitUntil(() => End == false);
       

    }

    void Turns()
    {
        if (napoleonturn == true)
        {
            NapoleonText.transform.parent.gameObject.SetActive(true);
            WellingtonText.transform.parent.gameObject.SetActive(false);
        }
        else
              if (napoleonturn == false)
        {
            NapoleonText.transform.parent.gameObject.SetActive(false);
            WellingtonText.transform.parent.gameObject.SetActive(true);
        }
    }


    void Dialogues()
    {
        StartCoroutine(Texts());
    }
}
