using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextOnStart : MonoBehaviour {

    float textTimer;
    public Text startText;

    void Start ()
    {
        //textTimer staat op 0, text geef text "Look up the sky for controls!" weer
        textTimer = 0;
        startText.text = "Look up the sky for controls!";
	}
	
	void Update ()
    {
        //elke seconde komt er 1 bij textTimer op, als textTimer op 5 of hoger staat verandert de text in " "
        textTimer += 1 * Time.deltaTime;
        if (textTimer >= 5)
        {
            startText.text = " ";
        }
	}
}
