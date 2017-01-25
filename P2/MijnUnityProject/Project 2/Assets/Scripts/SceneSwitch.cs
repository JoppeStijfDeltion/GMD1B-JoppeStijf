using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitch : MonoBehaviour {

    public void ChangeScene(int changeScene)
    {
        SceneManager.LoadScene(changeScene);
    }
}
