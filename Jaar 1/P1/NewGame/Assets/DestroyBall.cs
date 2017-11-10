using UnityEngine;
using System.Collections;

public class DestroyBall : MonoBehaviour {

    void OnCollisionEnter (Collision c)
    {
        if (c.gameObject.tag == "Kube")
        {
            Destroy(gameObject);
        }
    }
}
