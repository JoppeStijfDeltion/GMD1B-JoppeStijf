using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {

    public Movement movementScript;
    public CamRotation camRotateScript;
    public GameObject startScreen;
    public GameObject otherText;

    void Start()
    {
        movementScript = gameObject.GetComponent<Movement>();
        camRotateScript = gameObject.GetComponentInChildren<CamRotation>();

        startScreen.SetActive(true);
        otherText.SetActive(false);
    }

    void Update()
    {
        if (startScreen.activeSelf)
        {
            otherText.SetActive(false);
            gameObject.GetComponent<Movement>().enabled = false;
            gameObject.GetComponentInChildren<CamRotation>().enabled = false;
        }

        if (Input.GetButtonDown("Enter"))
        {
            otherText.SetActive(true);
            startScreen.SetActive(false);
            gameObject.GetComponent<Movement>().enabled = true;
            gameObject.GetComponentInChildren<CamRotation>().enabled = true;
        }
    }
}
