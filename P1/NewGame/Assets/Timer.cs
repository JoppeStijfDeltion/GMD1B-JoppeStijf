using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timetext;
    public float time = 0;

	public void Update ()
    {
        time += Time.deltaTime;
        timetext.text = "Time: " + time;
    }
}
