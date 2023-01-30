using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSounds : MonoBehaviour
{
    //Deklariranje

    public GameObject Player;

    AudioSource StartMusic;
    AudioSource SecondSound;

    void Start()
    {
        SecondSound = transform.Find("SecondSound").GetComponent<AudioSource>();
        StartMusic = transform.Find("StartMusic").GetComponent<AudioSource>();
    }

    void Update()
    {
        //Ako je x pozicija igraca manja od -56...
        if (Player.transform.position.x < -52.79f)
        {
            //Utisaj StartMusic, pojacaj CastleMusic
            StartMusic.mute = true;
            SecondSound.mute = false;
        }
        //Inace...
        else
        {
            //Utisaj CastleMusic, pojacaj StartMusic
            StartMusic.mute = false;
            SecondSound.mute = true;
        }
    }
}
