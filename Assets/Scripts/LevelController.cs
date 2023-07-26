using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static bool isFinished = false;

    public Corn corn;
    public Spawner spawner;
    // Start is called before the first frame update

    public GameObject passedPanel;
    public GameObject failedPanel;
    public static int level = 1;

    public string sceneName = "MainMenu";
    public void Check()
    {
        if (spawner.spawnCounter <= 0)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            if(enemies.Length <= 0 )
            {
                isFinished = true;
                Victory();
            }
        }

        if(Corn.singleton.Health <= 0)
        {
            isFinished = true;
            Defeat();
        }
;
    }

    // Update is called once per frame
    public void Victory()
    {
        passedPanel.SetActive(true);
        Debug.Log("You have completed the level with " + corn.Health + " health left!");
        level ++;
        GameController.SaveLevel();
    }

    public void Defeat()
    {
        failedPanel.SetActive(true);
        Debug.Log("You lost!");
    }

    void Update()
    {
        if (isFinished == false)
        {
        Check();
        }
    }

    public void RestartLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Start()
    {
        isFinished = false;
    }
    private void Awake()
    {
        level = PlayerPrefs.GetInt("level", 1);
    }
}
