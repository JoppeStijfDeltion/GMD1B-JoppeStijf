using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour {

	void Start ()
    {
        gameObject.GetComponent<Animator>().enabled = false;
	}
}
