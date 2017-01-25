using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Lifes : MonoBehaviour {

    public int health = 100;
    public Text healthText;

	
	void Update ()
    {
        AddPoints();
        if(health == 0)
        {
            SceneManager.LoadScene("project 2 start scene");
        }
	}

    void AddPoints ()
    {
        healthText.text = "Health: " + health;
    }

    void OnCollisionStay (Collision col)
    { 
        if (col.gameObject.tag == "Lava")
        {
            health -= 1;
        }
    }
}
