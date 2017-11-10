using UnityEngine;
using System.Collections;

public class RotateSlash : MonoBehaviour {

    public float slashTime = 360;
    public bool rotateCheck = false;


    void Update()
    {
        //voert elk frame functie Rotate() uit
        Rotate();
    }

    void Rotate()
    {
        //als knop "Fire1" ingedrukt word gaat rotateCheck op true
        if (Input.GetButtonDown("Fire1"))
        {
            rotateCheck = true;
        }
        
        //als er word geroteerd gaat er 1080 van slashTime af per seconde en, 
        //roteert het object per seconde op de aangegeven as met de aangegeven waarde
        if (rotateCheck)
        {
            slashTime -= 1080 * Time.deltaTime;
            transform.Rotate(0, 0, 1080 * Time.deltaTime);
        }
        
        //als slashTime lager dan 0 is, gaat rotateCheck uit en word slashTime 360
        if (slashTime <= 0)
        {
            if (rotateCheck)
            {
                rotateCheck = false;
                slashTime = 360;
            }
        }
    }
}
