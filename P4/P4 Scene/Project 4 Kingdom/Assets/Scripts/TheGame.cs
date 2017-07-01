﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGame : MonoBehaviour {

    //list en item die in de list word opgeslagen
    public int itemsInList;
    public List<GameObject> pickUps = new List<GameObject>(5);

    //speler, om naar scripts die op de player staan te verwijzen
    public Transform startPos;
    public GameObject playerBody;
    public Transform balconyPos;

    //beeld switch
    public GameObject mainCam;
    public GameObject switchCam;

    //Cramos statue komt omhoog
    public Transform statuePos;
    public Transform statuePosEnd;
    public Vector3 statueMove;
    public float lerpSpeed = 1.0f;

    //Raycast
    private RaycastHit hit;
    private float castRange = 10;

    public bool switched = true;
    public bool allPickUps = false;
    public bool statueLerp;
    bool hasSwitchedBack;
    bool doorOpened;

    //Transforms voor het camera switchen
    public Transform switchCamStatue;
    public Transform switchCamBalcony;
    public int switchTimes;
    public float seeRelicTime;

    //verandert de staat van de text;
    public int textLevel;

    public ChestAnimation animationScript;

	void Start ()
    {
        switchTimes = 0;
        mainCam.SetActive(true);
        switchCam.SetActive(false);

        textLevel = 1;
	}
	
	void Update ()
    {
        RayCast();

        SwitchCam();

        if (statueLerp)
        {
            statuePos.position = Vector3.Lerp(statuePos.position, statuePosEnd.position, Time.deltaTime * lerpSpeed);
        }

        if (switched && switchTimes == 0)
        {
            //text voor interactie met reliek
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "PickUp")
        {
            pickUps.Add(c.gameObject);
            Destroy(c.gameObject.GetComponent<MeshRenderer>());
            Destroy(c.gameObject.GetComponent<Collider>());
            itemsInList += 1;

            for (int i = 0; i < pickUps.Count; i++)
            {
                if (pickUps[i] != null)
                {
                    itemsInList = pickUps.Count;

                    if (itemsInList == pickUps.Capacity)
                    {
                        textLevel = 2;
                        allPickUps = true;
                    }
                }
            }
        }
    }

    void SwitchCam()
    {
        if (switchCam.activeSelf && switchTimes == 1)
        {
            playerBody.GetComponent<Movement>().enabled = false;
            mainCam.GetComponent<CamRotation>().enabled = false;
        }

        if (mainCam.activeSelf)
        {
            playerBody.GetComponent<Movement>().enabled = true;
            mainCam.GetComponent<CamRotation>().enabled = true;
        }

        if (switchTimes == 0)
        {
            switchCam.transform.position = switchCamBalcony.position;
            switchCam.transform.rotation = switchCamBalcony.rotation;
        }

        else if (switchTimes == 1 && switchCam.activeSelf)
        {
            seeRelicTime += Time.deltaTime;

            if (seeRelicTime >= 1)
            {
                switchCam.transform.position = switchCamStatue.position;
                switchCam.transform.rotation = switchCamStatue.rotation;
                statueLerp = true;
            }
        }

        if (seeRelicTime >= 4)
        {
            mainCam.SetActive(true);
            switchCam.SetActive(false);

            if (!hasSwitchedBack)
            {
                playerBody.transform.position = startPos.position;
                playerBody.transform.rotation = startPos.rotation;
                hasSwitchedBack = true;
            }
        }
    }

    void RayCast()
    {
        Debug.DrawRay(transform.position, transform.forward * castRange, Color.green, 0.2f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, castRange))
        {
            if (hit.collider.tag == "Relic" && allPickUps && textLevel == 2)
            {
                textLevel = 3;
            }

            if (hit.collider.tag == "Chest" && Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                hit.collider.gameObject.GetComponent<Collider>().enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.DrawRay(transform.position, transform.forward * castRange, Color.green, 0.2f);
            if (Physics.Raycast(transform.position, transform.forward, out hit, castRange))
            {
                if (hit.collider.tag == "Relic" && allPickUps)
                {
                    switchTimes = 1;
                    textLevel = 4;
                }

                if (hit.collider.tag == "Door" && allPickUps)
                {
                    playerBody.transform.position = balconyPos.transform.position;
                    playerBody.transform.rotation = balconyPos.transform.rotation;

                    if (switched)
                    {
                        switched = false;
                        switchCam.SetActive(true);
                    }
                }
            }
        }
    }
}