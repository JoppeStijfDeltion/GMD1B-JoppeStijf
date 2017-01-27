using UnityEngine;
using System.Collections;

public class PlayAudioInput : MonoBehaviour
{

    public AudioSource wepSlash;
    public AudioSource jumpSound;
    public Movement movementScript;


    void Update()
    {
        //speel audiosource "wepSlash" per keer dat de "Fire1" knop ingedrukt word
        if (Input.GetButtonDown("Fire1"))
        {
            wepSlash.Play();
        }
        //speel audiosource "jumpSound" per keer dat de "Jump" knop ingedrukt word
        {
            if (movementScript.jumpCount <= 3)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    jumpSound.Play();
                }
            }
        }
    }
}
