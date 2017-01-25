using UnityEngine;
using System.Collections;

public class RotateSlash : MonoBehaviour {

    public float slashTime = 360;
    public bool rotateCheck = false;


    void Update()
    {
       
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rotateCheck = true;
        }

        if (rotateCheck)
        {
            slashTime -= 1080 * Time.deltaTime;
        }

        if (slashTime <= 0)
        {
            if (rotateCheck)
            {
                rotateCheck = false;
                slashTime = 360;
            }
        }

        if (rotateCheck)
        {
            transform.Rotate(0, 0, 1080*Time.deltaTime);
        }
    }
}
