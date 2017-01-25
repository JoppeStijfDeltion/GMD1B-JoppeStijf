using UnityEngine;
using System.Collections;

public class SwitchWeapon : MonoBehaviour {

    public GameObject weapon1;
    public GameObject weapon2;

	void Start ()
    {
        weapon2.SetActive(false);
	}
	
	void Update ()
    {
	if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapons();
        }
	}

    void SwitchWeapons()
    {
        if (weapon1.activeSelf)
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
        }

        else
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
        }
    }
}
