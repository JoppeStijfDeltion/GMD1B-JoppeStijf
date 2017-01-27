using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchWeapon : MonoBehaviour {


    public GameObject weapon1;
    public GameObject weapon2;

    public Text modeText;
    public GameManager goldScript;

    public float modeTimer;
    public Text timeText;


	void Start ()
    {
        //wanner de scene start staat weapon2 uit en zijn beide texten leeg (" ")
        weapon2.SetActive(false);
        modeText.text = " ";
        timeText.text = " ";
	}

    public void Update()
    {
        //als weapon1 actief is
        if (weapon1.activeSelf)
        {
            //en als tenPlus aan staat
            if (goldScript.tenPlus == true)
            {
                //en als de key "Q" word ingedrukt
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //komt er per seconde 1 bij modeTimer op
                    //voert functie SwitchWeapons() uit
                    //gaat tenPlus uit
                    //veranderd goldText in "Gold " + waarde van goldScore
                    //gaat er 10 van goldScore af
                    modeTimer += 1 * Time.deltaTime;
                    SwitchWeapons();
                    goldScript.tenPlus = false;
                    goldScript.goldText.text = ("Gold ") + goldScript.goldScore;
                    goldScript.goldScore -= 10;
                }
            }
        }

        //als weapon2 actief is
        if (weapon2.activeSelf)
        {
            //is timetext "Time: " + waarde van modeTimer
            //gaat er elke seconde 1 van modeTimer af
            //verander modeText in "GODMODE ACTIVATED"
            timeText.text = "Time: " + modeTimer;
            modeTimer -= 1 * Time.deltaTime;
            modeText.text = "GODMODE ACTIVATED";
            //als modeTimer lager dan 0 is
            if (modeTimer <= 0)
            {
                //functie SwitchWeapons() word uitgevoerd
                //modeTimer staat weer op 5
                //beide texten zijn leeg (" ")
                SwitchWeapons();
                modeTimer = 5;
                modeText.text = " ";
                timeText.text = " ";
            }
        }
    }

    public void AddTime()
    {
        //timeText word aangegeven met "Time: " + waarde van modeTimer
        //er gaat per seconde 1 van modeTimer af
        timeText.text = "Time: " + modeTimer;
        modeTimer -= 1 * Time.deltaTime;
    }

    void SwitchWeapons()
    {
        //als weapon1 actief is
        if (weapon1.activeSelf)
        {
            //weapon1 kan niet geactiveerd worden, weapon2 wel
            weapon1.SetActive(false);
            weapon2.SetActive(true);
        }
        //anders
        else
        {
            //weapon2 kan niet geactiveerd worden, weapon1 wel
            weapon1.SetActive(true);
            weapon2.SetActive(false);
        }
    }
}
