using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalUI : MonoBehaviour
{
    public Text crystalText;

    // This method will display the current crystal amount on the HUD.
    void Update()
    {
        crystalText.text = Corn.Crystals.ToString();        
    }


}
