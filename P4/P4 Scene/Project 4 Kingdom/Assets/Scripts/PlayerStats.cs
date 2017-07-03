using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public Transform startPos;
    public Transform playerPos;
    public int lives = 3;
    public Text livesText;

    public AudioSource getHitSound;

    void Start()
    {
        livesText.text = "Lives: " + lives;
    }

    void Update()
    {
        livesText.text = "Lives: " + lives;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Enemy")
        {
            getHitSound.Play();
            lives -= 1;
            playerPos.position = startPos.position;
        }
    }
}
