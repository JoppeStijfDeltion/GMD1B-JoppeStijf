using UnityEngine;
using System.Collections;

public class NewScript : MonoBehaviour {

    public int int1;
    public float float1;

	// Use this for initialization
	void Start ()
    {
        int1 = 0;
        float1 = 0;
    }
	
	// Update is called once per frame
	void Update()
    {

    }
    
    public void TestVoid (int i, float f)
    {
        int1 = int1 + i;
        float1 = float1 + f;
    }
}
