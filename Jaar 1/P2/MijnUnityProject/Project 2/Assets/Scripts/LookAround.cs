using UnityEngine;
using System.Collections;

public class LookAround : MonoBehaviour {

    public Vector3 bodyX;
    public Vector3 camX;
    public GameObject cam;
    public GameObject body;

    void Update()
     {
        //roteer gameobject (camX) op de Y-as door de muis(pad) te bewegen
        camX.x = -Input.GetAxis("Mouse Y");
        {
            cam.transform.Rotate(camX);
        }
        //roteer gameobject (bodyX) op de X-as door de muis(pad) te bewegen
        bodyX.y = Input.GetAxis("Mouse X");
        {
            body.transform.Rotate(bodyX);
        }
    }
}
