using UnityEngine;
using System.Collections;

public class Score2 : MonoBehaviour{

    public int livesGiven;
    public int pointsGiven;
    public Score scoreScript;
    public Lives livesScript;

    //veranderd het aantal punten bij aanraking
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Pinball")
        {
            scoreScript.AddScore(pointsGiven);
            livesScript.AddLives(livesGiven);
        }
    }
}