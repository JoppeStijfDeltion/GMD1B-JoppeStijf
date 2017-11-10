using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

    public Vector3 rotateAxis;
    public float rotateSpeed;

	void Update ()
    {
        transform.Rotate(rotateAxis * rotateSpeed * Time.deltaTime);
	}
}
