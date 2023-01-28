using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitInBoat : MonoBehaviour
{
    public GameObject player;
    public GameObject fakePlayer;
    public GameObject camera;
    public GameObject boat;
    Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb = player.GetComponent<Rigidbody2D>();
        if (collision.gameObject == player && boat.active == true)
        {
            player.GetComponent<Animator>().SetBool("Walking", false);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<SpriteRenderer>().enabled = false;

            player.transform.position = new Vector2(14.2f, -3.8f);

            fakePlayer.GetComponent<SpriteRenderer>().enabled = true;

            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            boat.GetComponent<Animator>().SetBool("InBoat", true);

            camera.transform.SetParent(transform);
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
