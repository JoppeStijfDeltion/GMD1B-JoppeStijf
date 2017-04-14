using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {
    //StartScreen Class, staat op de GameManager,
    //zorgt voor een leuke startscreen met roterende cam en een blur motion effect,
    //waarbij de speler het gevoel heeft zelf te bepalen wanneer hij het spel start

    public GameObject startCam;
    public GameObject playerCam;
    public GameObject player;
    public Vector3 camRotation;   

	void Start ()
    {
        //startCam is actief en speler kan niet bewegen
        startCam.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
	}
	
	void Update ()
    {
        //wanneer "Fire2" knop word ingedrukt word er van camera geswitched en kan,
        //de speler zich weer voortbewegen
		if (Input.GetButtonDown("Fire2"))
        {
            startCam.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
        }

        //wanneer startCam actief is roteert de cam met de waarde die meeword gegeven met vector3 camRotation per seconde
        if (startCam.activeSelf)
        {
            startCam.transform.Rotate(camRotation * Time.deltaTime);
        }
	}
}
