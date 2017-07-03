using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    /*
     * PlayerMovement Class, staat op het character,
     * zorgt ervoor dat het character kan bewegen
     * op alle soorten manieren, van lopen tot
     * springen tot rennen etc.
     */

    //lopen 
    public Vector3 move;
    public float walkSpeed;
    public float hor;
    public float ver;

    //rennen
    public float runSpeed;
    public bool runB;

    //springen
    public Vector3 jumpPower;
    public Rigidbody rBody;
    public int jumpCount = 0;


    public void Update()
    {
        Run();

        //lopen door de pijltjestoetsen in te drukken
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        move.x = hor;
        move.z = ver;

        transform.Translate(move * Time.deltaTime * walkSpeed);

        //springen door de "Jump" (Spatiebalk) knop in te drukken
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpCount < 3)
            {
                rBody.velocity = jumpPower;
                jumpCount += 1;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //aanraking gameObject met tag "TerrainFloor" reset de Jump Count
        if (col.gameObject.tag == "TerrainFloor")
        {
            jumpCount = 0;
        }
    }

    public void Run()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            walkSpeed *= runSpeed;
        }

        //wanneer de "Fire3" knop word losgelaten springt de bool op false en verkeerd
        //walkSpeed weer in zijn originele staat met de standaard waarde
        if (Input.GetButtonUp("Fire3"))
        {
            walkSpeed /= runSpeed;
            runB = false;
        }

        if (Input.GetButton("Fire3"))
        {
            runB = true;
        }
    }
}
