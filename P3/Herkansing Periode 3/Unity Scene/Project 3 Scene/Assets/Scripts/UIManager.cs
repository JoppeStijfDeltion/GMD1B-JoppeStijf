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

    //text voor interactie
    public Text interactText;
    public float interactTimer;

    public Text hitpointsText;
    public Text activeTimeText;

    public StartScreen startScript;
    public Game gameScript;

    void Start ()
    {
        startText.text = "Press RMB to Start";
        interactText.text = "Press E to Interact";
    }

    void Update()
    {
        activeTimeText.text = "Time Left: " + gameScript.activeTimer;
        hitpointsText.text = "Hitpoints: " + gameScript.hitpointsInt;

        UIText();

        VisualInteraction();

        if (gameScript.hitpoints >= 100)
        {
            hitpointsText.color = Color.red;
        }
        else if (gameScript.hitpoints <= 100)
        {
            hitpointsText.color = Color.white;
        }
        //bij indrukken van "Fire2' veranderd startText.text in " "
        if (Input.GetButtonDown("Fire2") && startText.text == "Press RMB to Start")
        {
            startText.text = " ";
        }

        if (startScript.startCam.activeSelf)
        {
            startText.text = "Press RMB to Start";
        }

        else if (!startScript.startCam.activeSelf)
        {
            startText.text = " ";
        }
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
