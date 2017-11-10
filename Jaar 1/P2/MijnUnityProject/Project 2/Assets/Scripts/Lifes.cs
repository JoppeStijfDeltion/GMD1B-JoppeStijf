using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Lifes : MonoBehaviour {

    public int health = 100;
    public Text healthText;

	
	void Update ()
    {
        //voert functie AddPoints elk frame uit
        AddPoints();

        //heb geen consequenties voor < 0 health omdat ik problemen had bij het switchen van scenes
	}

    void AddPoints ()
    {
        //health word weergegeven door text met daarachter de waarde van health
        healthText.text = "Health: " + health;
    }

    void OnCollisionStay (Collision col)
    { 
        //als gameobject in aanraking komt met collider van gamobject met tag "Lava" gaat er 1 van health af per frame
        if (col.gameObject.tag == "Lava")
        {
            health -= 1;
        }
    }
}
