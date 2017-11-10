using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    /*
     * UIManager Class, staat op Managers (empty game) object,
     * zorgt ervoor dat strings & texten worden weergegeven
     * op het scherm van de gebruiker en dat texten worden
     * verandert/bijgehouden wanneer nodig 
     */

    //text voor conversatie
    public Text textSentence;
    public string sentence;

    //text aan het begin van de scene
    public Text startText;

    //text voor bijhouden stamina
    public Text staminaTextUI;

    //text voor interactie
    public Text interactText;
    public float interactTimer;


    void Start ()
    {
        startText.text = "Press RMB to Start";
        interactText.text = "Press E to Interact";
    }

    void Update()
    {
        UIText();

        VisualInteraction();

        //bij indrukken van "Fire2' veranderd startText.text in " "
        if (Input.GetButtonDown("Fire2"))
        {
            startText.text = " ";
        }

        //er word aangegeven dat staminaTextUI.text het component staminaInt van script PlayerMovement in gameobject "Player" is
        staminaTextUI.text = "Stamina: " + GameObject.Find("Player").GetComponent<PlayerMovement>().staminaInt;
    }

    public void UIText()
    {
        //textSentence.text veranderd per frame in (text van) sentence
        textSentence.text = sentence;
    }

    void VisualInteraction()
    {
        //zorgt ervoor dat elke halve seconde interactText.text word veranderd in " ",
        //alleen wanneer de raycast geen npc detecteerd doormiddel van andere scripts
        interactTimer += 1 * Time.deltaTime;

        if (interactTimer >= 0.5)
        {
            interactText.text = " ";
            interactTimer = 0;
        }
    }
}
