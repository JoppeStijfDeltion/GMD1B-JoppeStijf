using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RayCast : MonoBehaviour {

    //ik heb bij deze class ook punten bij de variables geschreven, 
    //omdat het veel veschillende functies betreft

    //general raycast
    private RaycastHit hit;
    private float range = 5;

    //chest interact
    public Text interactButton;
    public bool whatText;

    //spawn gold
    public GameObject goldSpawner;
    public GameObject goldPiece;
    public int power;

    //interactive light
    public GameObject interactiveLight;
    public GameObject interactiveLight2;

    void Start()
    {
        //text begint met "Get To The Chest!"
        interactButton.text = "Get To The Chest!";
    }

    void Update()
    {
        //Debug Raycast met een lijn die strak vooruit staat
        Debug.DrawRay(transform.position, transform.forward * range, Color.cyan, 1.0f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            //als de raycast collider met tag "Chest" raakt (veranderd text)
            ChestInteract();
            //als whatText op true staat is de tekst "Press E 4 Gold",
            //en kan je goud spawnen met functie GoldSpawn()
            if (whatText == true)
            {
                GoldSpawn();
                interactButton.text = "Press E 4 Gold";
            }
            //anders, als whatText op false staat,
            //veranderd text in "Get to the Chest!"
            else if (whatText == false)
            {
                interactButton.text = "Get To The Chest!";
            }

            //als raycast collider met tag "Light" hit, voer functie Light() uit
            if (hit.collider.tag == "Light")
            {
                //en als key E ingedrukt word
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //en als component van interactiveLight (Light) uit staat, voer functie LightOn() uit
                    //voer anders functie LightOff() uit
                    if (interactiveLight.GetComponent<Light>().enabled == false)
                    {
                        LightOn();
                    }
                    else LightOff();
                }
            }
        }
    }

    void LightOn()
    {
        //component (Light) van interactiveLight staat aan
        interactiveLight.GetComponent<Light>().enabled = true;
        interactiveLight2.GetComponent<Light>().enabled = true;
    }

    void LightOff()
    {
        //component (Light) van interactiveLight staat uit
        interactiveLight.GetComponent<Light>().enabled = false;
        interactiveLight2.GetComponent<Light>().enabled = false;
    }

    void ChestInteract()
    {
        //als raycast collider met tag "Chest" hit, gaat whatText aan
        //anders gaat whatText uit
        if (hit.collider.tag == "Chest")
        {
            whatText = true;
        }
        else whatText = false;
    }

    void GoldSpawn()
    {
        //als key "E" word ingedrukt instatiate goldPiece uit goldSpawner met aangegeven waarde van power
        if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject PlayerPlaceHolder = (GameObject)Instantiate(goldPiece, goldSpawner.GetComponent<Transform>().
            position, goldSpawner.GetComponent<Transform>().rotation);

                PlayerPlaceHolder.GetComponent<Rigidbody>().velocity = goldSpawner.GetComponent<Transform>().transform.
                forward * power;
            }
    }
}
