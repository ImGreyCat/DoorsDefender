using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string SceneName;
    // Start is called before the first frame update
    public void OnClickPlay()
    {
        SceneManager.LoadScene(SceneName);
        Debug.Log("Successfully started loading");
    }

    // Update is called once per frame
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Successfully exited");
    }
}
