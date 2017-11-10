using UnityEngine;
using System.Collections;

public class FlipperMovement : MonoBehaviour {

    public float flipperstrength;
    public float pushForce;
    private HingeJoint hinge;

	// Use this for initialization
	void Start () {
        hinge = GetComponent<HingeJoint>();
	}

	void FixedUpdate () {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 f = transform.up * flipperstrength;
            Vector3 p = (transform.right) + transform.position * pushForce;
            GetComponent<Rigidbody>().AddForceAtPosition(f, p);
        }
	}
}
