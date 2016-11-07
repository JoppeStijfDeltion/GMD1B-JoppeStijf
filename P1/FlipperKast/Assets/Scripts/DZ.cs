using UnityEngine;
using System.Collections;

public class DZ : MonoBehaviour
{
    //Maakt pinball kapot
    public int levens;
    public Lives livesScript;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Pinball")
        {
            Destroy(col.gameObject);
            livesScript.AddLives(levens);
        }

    }
}	
