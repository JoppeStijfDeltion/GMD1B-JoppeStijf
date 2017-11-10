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
        relicText.text = "Relic Pieces: " + theGameScript.itemsInList + "/" + theGameScript.pickUps.Capacity;

        if (theGameScript.textLevel == 1)
        {
            interactText.text = "Find all the relic pieces!";
        }
        else if (theGameScript.textLevel == 2)
        {
            interactText.text = "Good job! Go to the castle doors and press E to interact.";
        }
        else if (theGameScript.textLevel == 3)
        {
            interactText.text = "Press E to place the relic in its stand.";
        }
        else if(theGameScript.textLevel == 4)
        {
            interactText.text = "Storyline Completed.";
        }
    }

}
