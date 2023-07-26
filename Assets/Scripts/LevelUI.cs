using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Text levelText;

    // Update is called once per frame
    void Update()
    {
        levelText.text = LevelController.level.ToString();
    }
}
