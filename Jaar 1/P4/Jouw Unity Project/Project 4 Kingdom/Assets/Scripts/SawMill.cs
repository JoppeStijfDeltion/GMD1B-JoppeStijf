using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMill : MonoBehaviour {

    private RaycastHit sawmillDetect;
    float castRange = 5f;

    public Vector3 bladeRotation;
    public GameObject bladeBeingSpinned;
    public bool beingSpinned;
    public Transform playerPosition;
    public float bladeSpeed = 1;

    public void Start()
    {
        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    public void Update ()
    {
        SawMillRayCast();

        if (Input.GetButtonUp("Fire3") && beingSpinned == true)
        {
            beingSpinned = false;
        }

        if (beingSpinned == true)
        {
            bladeBeingSpinned.transform.Rotate(bladeRotation * Time.deltaTime * bladeSpeed);
            if (bladeSpeed <= 15)
            {
                bladeSpeed += 5 * Time.deltaTime;
            }
        }

        if (beingSpinned == false && bladeSpeed >= 0)
        {
            bladeBeingSpinned.transform.Rotate(bladeRotation * Time.deltaTime * bladeSpeed);
            bladeSpeed -= 5 * Time.deltaTime;
        }
    }

    public void SawMillRayCast()
    {
        Debug.DrawRay(playerPosition.position, playerPosition.forward * castRange, Color.green, 0.2f);
        if (Physics.Raycast(playerPosition.position, playerPosition.forward, out sawmillDetect, castRange))
        {
            if (sawmillDetect.collider.tag == "Saw")
            {
                bladeBeingSpinned = sawmillDetect.collider.gameObject;
                playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }

            if (Input.GetButtonDown("Fire3") && sawmillDetect.collider.tag == "Saw")
            {
                print("Sawmill seen");
                beingSpinned = true;
            }
        }
    }
}
