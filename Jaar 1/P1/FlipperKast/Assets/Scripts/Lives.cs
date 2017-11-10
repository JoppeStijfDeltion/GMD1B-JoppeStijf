using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour {

    public Text lifetext;
    int life = 5;
    public PinballSpawn pinballspawnscript;

	//functie levens toevoegen
	public void AddLives (int points)
    {
        life += points;
        lifetext.text = "Balls: " + life;
        //als er 0 of minder levens over zijn stopt het spel
        if (life <= 0)
        {
            lifetext.text = "Balls: 0"; 
            SceneManager.LoadScene("Game Over Screen"); 
        }
        //als je levens hoger zijn dan 0 kan je een bal spawnen
        else
        {
            pinballspawnscript.ballSpawn = true;
        }
	}
}
