using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float power;
    public GameObject prefab;
    public GameObject spawner;

    public void Spawn()
    {
        GameObject Sphere = (GameObject)Instantiate(prefab, spawner.GetComponent<Transform>().position, spawner.GetComponent<Transform>().rotation);

        Sphere.GetComponent<Rigidbody>().velocity = spawner.GetComponent<Transform>().transform.forward * power;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Spawn();
        }
    }
}
