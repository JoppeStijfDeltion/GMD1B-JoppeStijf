using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    //lopen 
    public Vector3 move;
    public float power;
    public float hor;
    public float ver;

    //rennen
    public float run;
    
    //springen
    public Vector3 jumpPower;
    public Rigidbody rBody;
    public int jumpCount = 0;

    void Update()
    {
        //lopen door de pijltjestoetsen in te drukken
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        move.x = hor;
        move.z = ver;

        transform.Translate(move * Time.deltaTime * power);

        //rennen door de "Fire3" (L Shift) knop in te drukken
        if (Input.GetButtonDown("Fire3"))
        {
            power *= run;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            power /= run;
        }

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
    
    void OnCollisionEnter (Collision col)
    {
        //aanraking gameObject met tag "TerrainFloor" reset de Jump Count
        if (col.gameObject.tag == "TerrainFloor")
        {
            jumpCount = 0;
        }
    }
}
