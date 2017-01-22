using UnityEngine;
using System.Collections;

public class Beweging : MonoBehaviour {

    public Vector3 v3;
    public float hor;
    public float ver;
    public float snelheid;
    public float tijd;

    void Update()
    {
        hor = Input.GetAxis ("Horizontal");
        ver = Input.GetAxis ("Vertical");

        v3.x = hor;
        v3.z = ver;

        transform.Translate(v3 * Time.deltaTime * snelheid);

        tijd += Time.deltaTime;
    }
}
