using UnityEngine;
using System.Collections;

public class BalCol : MonoBehaviour {

    public NewScript score;
	  
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cube")
        {
            score.TestVoid(50, 2.5f);
        }

        if (col.gameObject.tag == "Cube1")
        {
            score.TestVoid(100, 5.5f);
        }

        if (col.gameObject.tag == "Cube2")
        {
            score.TestVoid(200, 7.4f);
        }
    }
}
