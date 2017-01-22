using UnityEngine;
using System.Collections;

public class AddBTW : MonoBehaviour {

    public float levens = 500.5f;
    public float procentDamage;

    public void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Cube") Add(procentDamage);
    }

    public float Add(float f)
    {
        levens *= procentDamage;
        return f;
    }
}
