using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
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
    //stamina
    public Text staminaText;
    public float stamina = 100;
    public int staminaInt;

    //springen
    public Vector3 jumpPower;
    public Rigidbody rBody;
    public int jumpCount = 0;


    public void Update()
    {
        Run();
        Stamina();

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
        //rennen door de "Fire3" (L Shift) knop in te drukken stamina hoger dan 0 is
        if (stamina >= 0)
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

    public void Stamina()
    {
        //stamina float word afgerond naar de dichstbijzijnde integer staminaInt
        staminaInt = Mathf.RoundToInt(stamina);

        //als er gerend word ("Fire3" word ingedrukt) gaat er 10 waarde per seconde van stamina af
        if (runB == true)
        {
            if (stamina >= 1)
            {
                stamina -= 10 * Time.deltaTime;
            }
        }

        //anders als er niet gerend word en de waarde van stamina is lager dan 100, 
        //komt er elke seconde 1 waarde bij stamina bij
        else if (runB == false)
        {
            if (stamina <= 100)
            {
                stamina += 1 * Time.deltaTime;
            }
        }
    }
}

