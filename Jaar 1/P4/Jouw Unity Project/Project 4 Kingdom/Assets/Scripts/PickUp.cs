using System.Collections;
using UnityEngine;


public class PickUp : MonoBehaviour {

    public AudioSource pickupSound;

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Light>().enabled = false;
            pickupSound.Play();
        }
    }
}
