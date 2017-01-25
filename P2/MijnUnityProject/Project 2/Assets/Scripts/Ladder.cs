using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

    public float levitateSpeed;

    void OnCollisonEnter (Collision col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            transform.Translate(0, levitateSpeed, 0);
        }
    }
}
