using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip colorSwitchSound, winSound;
    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        colorSwitchSound = Resources.Load<AudioClip>("pop");
        winSound = Resources.Load<AudioClip>("victory");
        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "colorChange":
                audioSrc.PlayOneShot(colorSwitchSound);
                break;

            case "winSound":
                audioSrc.PlayOneShot(winSound);
                break;
        }
    }
}
