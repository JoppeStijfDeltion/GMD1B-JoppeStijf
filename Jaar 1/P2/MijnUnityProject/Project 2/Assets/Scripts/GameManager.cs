using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int goldScore;
    public Text goldText;
    public bool tenPlus;

    public List<AudioClip> newAudioList = new List <AudioClip>();


    public void Start()
    {
        //goldscore begint met 1, text begint met "Gold: "
        goldScore = 1;
        goldText.text = "Gold: ";

        //tenPlus is false 
        tenPlus = false;
    }

    public void Update()
    {
        //als goldScore hoger dan 10 is, tenPlus is true
        if (goldScore >= 10)
        {
            tenPlus = (true);
        }
    }

    public void AddGold()
    {
        //goldText is "Gold *goldScore hier*" ,
        //elke keer dat AddGold() word uitgevoerd komt er 1 bij goldScore op
        goldText.text = "Gold: " + goldScore;
        goldScore += 1;
    }

    void Awake()
    {
        //als er geen instance (gameManager) is, is de gameManager dit
            if (instance == null)
                instance = this;
            else if (instance != null)            
                Destroy(gameObject);            
    }

    public void Collect(int passedValue, GameObject passedObject)
    {
        //als de renderer van passedObject niet meer bestaat, vernietig passedObject na een halve seconde
        passedObject.GetComponent<Renderer>().enabled = false;
        Destroy(passedObject, 0.5f);

        //als de renderer van passedObject niet meer bestaat, voer functie AddGold() uit
        if (passedObject.GetComponent<Renderer>().enabled == false)
        {
            AddGold();
        }
    }
}
