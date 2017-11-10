using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoFun : MonoBehaviour {

    int money = 0;
    public Text moneytext;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            money += 1;
        }
    }
}
