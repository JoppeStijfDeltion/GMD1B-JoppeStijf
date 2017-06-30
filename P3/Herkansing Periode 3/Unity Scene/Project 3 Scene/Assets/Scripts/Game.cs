using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public float hitpoints = 100;
    public int hitpointsInt;

    public float activeTimer;
    public int activeTimerInt;
    public int startTime = 60;

    public Transform startPosition;
    public Transform playerPosition;

    public StartScreen startScript;

    public AudioSource dieSound;

    void Start()
    {
        playerPosition = gameObject.transform;
        activeTimer = startTime;
    }

    public void Update()
    {
        hitpointsInt = Mathf.RoundToInt(hitpoints);

        if (gameObject.GetComponent<PlayerMovement>().enabled == true)
        {
            activeTimer -= Time.deltaTime;
        }

        if (hitpoints <= 1 || activeTimer <= 0)
        {
            playerPosition.position = startPosition.position;
            activeTimer = startTime;
            hitpoints = 100;
            startScript.startCam.SetActive(true);
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            dieSound.Play();
        }

        if (hitpoints >= 100)
        {
            hitpoints -= 1 * Time.deltaTime;
        }

        if (hitpoints >= 250)
        {
            hitpoints = 250;
        }
    }

    public void OnCollisionStay(Collision col)
    {
        if (col.collider.tag == "Water")
        {
            hitpoints -= 500 * Time.deltaTime;
            activeTimer -= 1 * Time.deltaTime;
        }

        if (col.collider.tag == "HealthPickUp" && hitpoints <= 250)
        {
            hitpoints += 100;
            Destroy(col.collider.gameObject);
        }

        if (col.collider.tag == "TimePickUp")
        {
            activeTimer += 15;
            Destroy(col.collider.gameObject);
        }
    }
}
