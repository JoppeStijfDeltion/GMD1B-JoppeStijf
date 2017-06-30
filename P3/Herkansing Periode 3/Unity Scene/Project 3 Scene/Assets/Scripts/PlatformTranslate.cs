using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTranslate : MonoBehaviour {

    public float translateSpeed;
    public Vector3 position1vector;
    public Vector3 position2vector;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Position1")
        {
            print("TOUCHED 1");
            transform.Translate(position1vector * Time.deltaTime * translateSpeed);
        }

        if (c.gameObject.tag == "Position2")
        {
            print("TOUCHED 2");
            transform.Translate(position2vector * Time.deltaTime * translateSpeed);
        }
    }
}
