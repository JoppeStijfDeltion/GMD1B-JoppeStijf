using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text interactText;
    public Text relicText;

    public TheGame theGameScript;

    void Update()
    {
        relicText.text = "RELIC PIECES: " + theGameScript.itemsInList + "/" + theGameScript.pickUps.Capacity;

        if (theGameScript.textLevel == 1)
        {
            interactText.text = "FIND ALL THE RELIC PIECES!";
        }
        else if (theGameScript.textLevel == 2)
        {
            interactText.text = "GOOD JOB! GO TO THE CASTLE DOORS AND PRESS E TO INTERACT!";
        }
        else if (theGameScript.textLevel == 3)
        {
            interactText.text = "PRESS E TO PLACE THE RELIC IN THE STAND!";
        }
        else if(theGameScript.textLevel == 4)
        {
            interactText.text = " ";
        }
    }

}
