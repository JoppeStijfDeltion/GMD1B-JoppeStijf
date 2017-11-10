using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    int score = 0;
    public Text scoreText;
	
    //functie score toevoegen en text wijzigen
	public void AddScore (int points)

    {
        score += points;
        scoreText.text = "Score:" + score;
	}
}
