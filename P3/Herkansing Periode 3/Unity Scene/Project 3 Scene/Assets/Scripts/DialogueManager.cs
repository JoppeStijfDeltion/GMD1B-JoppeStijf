using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    /*                                              |
     * DialogueManager Class; Staat op de player,   |
     *  zorgt ervoor dat gesprekken gevoerd kunnen  |
     *  worden door samen te werken met de UIManager|
     *  word de tekst weergegeven op het scherm van |
     *  de gebruiker en doormiddel van de Dialogue  |
     *  class worden strings via de UIManager op    | 
     *  het scherm geplaatst en in een text omgezet |
     */                                           


    //dialogue benodigdheden
    public Dialogue dialogueScript;
    public GameObject playerBody;
    public int dialogueIndexInt;
    public GameObject textBox;
    public int sizeOfList;

    //raycast benodigdheden
    private RaycastHit rayCast;
    public float castRange;

    //UIManager & Text
    public UIManager uiScript;
    //interact text
    public GameObject interactTextObject;
    public GameObject cubeMove;
    public Vector3 moveCube;
    public int yesOrNo;

    void Start()
    {
        interactTextObject.SetActive(false);
        textBox.SetActive(false);
        dialogueIndexInt = 0;
        yesOrNo = 0;
    }

    void Update ()
    {
        TextBox();

        RayCastDialogue();

        YesOrNo();
    }

    void TextBox()
    {
        //als de textbox actief is
        if (textBox.activeSelf)
        {
            //staat "interactTextObject" op actief
            interactTextObject.SetActive(true);
            //als de "Fire2" knop word ingedrukt of
            //de dialogueIndexInt gelijk staat aan de waarde van indexSize
            if (Input.GetButtonDown("Fire2") || dialogueIndexInt == dialogueScript.indexSize)
            {
                //waarde van dialogueIndexInt word gereset, textbox wordt non-actief gezet,
                //components van playerBody worden actief
                dialogueIndexInt = 0;
                textBox.SetActive(false);
                playerBody.GetComponent<PlayerMovement>().enabled = true;
                playerBody.GetComponent<CamRotation>().enabled = true;
            }

            //zorgt ervoor dat met input, een keuze word gemaakt tussen yes/no
            //met als gevolg dat "cubeMove" word geroteerd met waarde van "moveCube"
            if (Input.GetKeyDown(KeyCode.Y))
            {
                yesOrNo += 1;
                cubeMove.transform.Rotate(moveCube);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                yesOrNo -= 1;
                cubeMove.transform.Rotate(-moveCube);
            }
        }
    }

    void RayCastDialogue()
    {
        //schiet een raycast met een groene drawray debug
        Debug.DrawRay(transform.position, transform.forward * castRange, Color.green, 0.2f);
        if (Physics.Raycast(transform.position, transform.forward, out rayCast, castRange))
        {
            //als raycast collider met tag "NPC" raakt
            if (rayCast.collider.tag == "NPC")
            {
                //interacTextObject word actief gezet, interactText.text uit uiScript word veranderd
                interactTextObject.SetActive(true);
                uiScript.interactText.text = "Press E to Interact";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //wanneer KeyCode E word ingedrukt word waarde yesOrNo & dialogueIndexInt gereset,
                    //dialogueScript word ingevult door Dialogue script dat de geraycaste collider met tag "NPC" bij zich draagt
                    //components van playerBody worden uitgezet waardoor het character stilstaat
                    //textBox word actief gezet
                    //waarde van sentence uit uiScript word gelijk gezet aan waarde van dialogueIndexInt
                    yesOrNo = 0;
                    dialogueIndexInt = 0;
                    dialogueScript = rayCast.collider.GetComponent<Dialogue>();
                    playerBody.GetComponent<PlayerMovement>().enabled = false;
                    playerBody.GetComponent<CamRotation>().enabled = false;
                    textBox.SetActive(true);
                    uiScript.sentence = dialogueScript.dialogueList[dialogueIndexInt];
                }

                //als er word geantwoord met Y of N gaat de waarde van dialogueIndexInt met 1 omhoog,
                //waardoor het gesprek verdergaat
                if (Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.N))
                {
                    dialogueIndexInt += 1;
                    uiScript.sentence = dialogueScript.dialogueList[dialogueIndexInt];
                }
            }
        }
    }

    void YesOrNo()
    {
        //consqequenties aan veel Yes of No antwoorden doormiddel van transformatie
        if(yesOrNo > 3)
        {
            cubeMove.transform.Rotate(80, 80, 80 * Time.deltaTime);
        }
        else if (yesOrNo < -2)
        {
            cubeMove.transform.Translate(0, 0.01f, 0 * Time.deltaTime);
        }
    }
}
