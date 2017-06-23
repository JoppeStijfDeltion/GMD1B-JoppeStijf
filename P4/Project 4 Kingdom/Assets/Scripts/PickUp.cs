using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public GameObject[] pickUps;

	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        if (OnTriggerEnter)
        {
            pickUps++;
        }
    }
}
