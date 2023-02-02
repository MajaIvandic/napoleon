using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSounds : MonoBehaviour
{
    public GameObject Player;

    AudioSource StartMusic;
    AudioSource SecondMusic;

    void Start()
    {
        SecondMusic = transform.Find("SecondMusic").GetComponent<AudioSource>();
        StartMusic = transform.Find("MainMusic").GetComponent<AudioSource>();
    }

    void Update()
    {
        //Ako je x pozicija igraca manja od -56...
        if (Player.transform.position.x > -52.79f)
        {
            //Utisaj StartMusic, pojacaj CastleMusic
            StartMusic.mute = false;
            SecondMusic.mute = true;
        }
        //Inace...
        else
        {
            //Utisaj CastleMusic, pojacaj StartMusic
            SecondMusic.mute = false;
            StartMusic.mute = true;
        }
    }
}
