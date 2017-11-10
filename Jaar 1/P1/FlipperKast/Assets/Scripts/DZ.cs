using UnityEngine;
using System.Collections;

public class DZ : MonoBehaviour
{
    public int levens;
    public Lives livesScript;

    //bij aanraking word het gameObject met de tag "Pinball" vernietigd en gaan de levens eraf (of mogelijk erop)
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Pinball")
        {
            Destroy(col.gameObject);
            livesScript.AddLives(levens);
        }

    }
}	
