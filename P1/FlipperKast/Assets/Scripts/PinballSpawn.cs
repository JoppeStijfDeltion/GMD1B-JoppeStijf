using UnityEngine;
using System.Collections;

public class PinballSpawn : MonoBehaviour
{

    public float power;
    public GameObject prefab;
    public GameObject pinballSpawn;
    public bool ballSpawn;

    //geeft drie waarden aan over hoe de pinball moet spawnen
    public void SpawnPinball()
    {
        GameObject pinball = (GameObject)Instantiate(prefab, pinballSpawn.GetComponent<Transform>()
        .position, pinballSpawn.GetComponent<Transform>().rotation);

        pinball.GetComponent<Rigidbody>().velocity = pinballSpawn.GetComponent<Transform>()
        .transform.forward * power;
    }
    //spawnpinball met de linker-muis knop
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ballSpawn)
            {
                SpawnPinball();
                ballSpawn = false;
            }
        }
    }
}

