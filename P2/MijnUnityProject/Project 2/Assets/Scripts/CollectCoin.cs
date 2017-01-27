using UnityEngine;
using System.Collections;

public class CollectCoin : MonoBehaviour {

    public int value;
    public float rotateSpeed;

	void Update ()
    {
        //gameObject roteert per seconde met aangegeven waarde
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
	}

    void OnTriggerEnter()
    {
        //collect gameobject on trigger en speelt audiosource af
        GameManager.instance.Collect(value, gameObject);
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
    }
}
