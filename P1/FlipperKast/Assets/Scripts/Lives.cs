using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour {

    public Text lifetext;
    int life = 3;
    public PinballSpawn pinballspawnscript;

	//functie levens toevoegen
	public void AddLives (int points)
    {
        life += points;
        lifetext.text = "Life: " + life;
        //als er 0 of minder levens over zijn stopt het spel
        if (life <= 0)
        {
            lifetext.text = "Life: 0"; 
            SceneManager.LoadScene("Game Over Screen"); 
        }

        else
        {
            pinballspawnscript.ballSpawn = true;
        }
	}
}
