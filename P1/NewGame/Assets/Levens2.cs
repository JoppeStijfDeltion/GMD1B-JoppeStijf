using UnityEngine;
using System.Collections;

public class Levens2 : MonoBehaviour {

    public int levens;
    public Levens1 livesScript;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Kube")
        {
            livesScript.AddLives(levens);
        }
    }
}
