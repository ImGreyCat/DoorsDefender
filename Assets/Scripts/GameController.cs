using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Levels, save clearing
    public static void SaveLevel()
    {
        PlayerPrefs.SetInt("level", LevelController.level);
    }
    public void DeleteSave()
    {
        RemoveLevel();
        ClearCrystals();
        ClearHealthUpgrades();
        ClearDmgUpgrades();
        ClearSpdUpgrades();
    }
    public static void RemoveLevel()
    {
        LevelController.level = 1;
        PlayerPrefs.SetInt("level", LevelController.level);
    }
    #endregion

    #region Crystals
    public static void SaveCrystals()
    {
        PlayerPrefs.SetInt("coins", Corn.Crystals);
    }

    public static void ClearCrystals()
    {
        PlayerPrefs.SetInt("coins", 0);
    }
    #endregion

    #region Health
    public static void SaveHealthUpgrade()
    {
        PlayerPrefs.SetInt("healthPurchased", UpgradeController.healthPurchased);
    }
    public static void SaveHealthUpPrice()
    {
        PlayerPrefs.SetInt("healthUpPrice", UpgradeController.healthUpPrice);
    }

    public static void ClearHealthUpgrades()
    {
        PlayerPrefs.SetInt("healthPurchased", 0);
        PlayerPrefs.SetInt("healthUpPrice", 10);
    }
    #endregion

    #region Damage
    public static void SaveDmgUpgrades()
    {
        PlayerPrefs.SetInt("dmgPurchased", UpgradeController.dmgPurchased);
    }

    public static void SaveDmgUpPrice()
    {
        PlayerPrefs.SetInt("dmgUpPrice", UpgradeController.dmgUpPrice);
    }

    public static void ClearDmgUpgrades()
    {
        PlayerPrefs.SetInt("dmgPurchased", 0);
        PlayerPrefs.SetInt("dmgUpPrice", 10);
    }
    #endregion

    #region Speed
    public static void SaveSpdUpgrades()
    {
        PlayerPrefs.SetInt("spdPurchased", UpgradeController.spdPurchased);
    }

    public static void SaveSpdUpPrice()
    {
        PlayerPrefs.SetInt("spdUpPrice", UpgradeController.spdUpPrice);
    }

    public static void ClearSpdUpgrades()
    {
        PlayerPrefs.SetInt("spdPurchased", 0);
        PlayerPrefs.SetInt("spdUpPrice", 10);
    }
    #endregion
}