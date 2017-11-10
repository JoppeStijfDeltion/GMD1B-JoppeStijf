using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Levens1 : MonoBehaviour {

    public Text lifetext;
    int life = 3;

    public void AddLives (int points)
    {
        life += points;
        lifetext.text = "Lifes: " + life;
    }
}
