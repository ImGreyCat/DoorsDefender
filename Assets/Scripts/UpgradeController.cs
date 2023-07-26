using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public Text healthUpPriceText;
    public Text dmgUpPriceText;
    public Text spdUpPriceText;

    public static int healthUpPrice = 10;
    public static int dmgUpPrice = 10;
    public static int spdUpPrice = 10;
    public static int healthPurchased;
    public static int dmgPurchased;
    public static int spdPurchased;

    void Awake()
    {
        healthPurchased = PlayerPrefs.GetInt("healthPurchased", 0);
        dmgPurchased = PlayerPrefs.GetInt("dmgPurchased", 0);
        spdPurchased = PlayerPrefs.GetInt("spdPurchased", 0);
        healthUpPrice = PlayerPrefs.GetInt("healthUpPrice", 10);
        dmgUpPrice = PlayerPrefs.GetInt("dmgUpPrice", 10);
        spdUpPrice = PlayerPrefs.GetInt("spdUpPrice", 10);
        
    }

    // Update is called once per frame
    void Update()
    {
        healthUpPriceText.text = healthUpPrice.ToString();
        dmgUpPriceText.text = dmgUpPrice.ToString();
        spdUpPriceText.text = spdUpPrice.ToString();
    }

    public void OnClickUpHealth()
    {
        if (healthUpPrice <= Corn.Crystals)
        {
            healthPurchased++;
            GameController.SaveHealthUpgrade();
            healthPurchased = PlayerPrefs.GetInt("healthPurchased", 0);
            healthUpPrice += 10;
            GameController.SaveHealthUpPrice();
            Corn.singleton.SpendCrystals(healthUpPrice);
        }
    }

    public void OnClickUpDmg()
    {
        if(dmgUpPrice <= Corn.Crystals)
        {
            dmgPurchased++;
            GameController.SaveDmgUpgrades();
            dmgPurchased = PlayerPrefs.GetInt("dmgPurchased", 0);
            dmgUpPrice += 10;
            GameController.SaveDmgUpPrice();
            Corn.singleton.SpendCrystals(dmgUpPrice);
        }
    }

    public void OnClickUpSpd()
    {
        if (dmgUpPrice <= Corn.Crystals)
        {
            spdPurchased++;
            GameController.SaveSpdUpgrades();
            spdPurchased = PlayerPrefs.GetInt("spdPurchased", 0);
            spdUpPrice += 10;
            GameController.SaveSpdUpPrice();
            Corn.singleton.SpendCrystals(spdUpPrice);
        }
    }
}
