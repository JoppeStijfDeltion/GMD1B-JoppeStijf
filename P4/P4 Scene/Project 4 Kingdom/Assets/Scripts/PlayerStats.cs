using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public Transform startPos;
    public Transform playerPos;
    public int lives = 3;
    public Text livesText;

    void Start()
    {
        livesText.text = "LIVES: " + lives;
    }

    void Update()
    {
        livesText.text = "LIVES: " + lives;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Enemy")
        {
            lives -= 1;
            playerPos.position = startPos.position;
        }
    }
}
