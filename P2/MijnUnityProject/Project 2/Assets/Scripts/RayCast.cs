using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RayCast : MonoBehaviour {

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


    void Start()
    {
        interactButton.text = "Get To The Chest!";
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * range, Color.cyan, 1.0f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            ChestInteract();
            if (whatText == true)
            {
                GoldSpawn();
                interactButton.text = "Press E 4 Gold";
            }
            else if (whatText == false)
            {
                interactButton.text = "Get To The Chest!";
            }
        }
    }

    void ChestInteract()
    {
        if (hit.collider.tag == "Chest")
        {
            whatText = true;
        }
        else whatText = false;
    }

    void GoldSpawn()
    {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject PlayerPlaceHolder = (GameObject)Instantiate(goldPiece, goldSpawner.GetComponent<Transform>().
            position, goldSpawner.GetComponent<Transform>().rotation);

                PlayerPlaceHolder.GetComponent<Rigidbody>().velocity = goldSpawner.GetComponent<Transform>().transform.
                forward * power;
            }
    }
}
