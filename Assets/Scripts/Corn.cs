using UnityEngine;

public class Corn : MonoBehaviour
{
    public int startHealth = 40;
    public int healthPerUpgrade = 10;
    public int Health;
    public static Corn singleton;
    public static int Crystals = 0;

    private void Awake()
    {
        singleton = this;
        Crystals = PlayerPrefs.GetInt("coins", 0);

        int healthBonus = healthPerUpgrade * PlayerPrefs.GetInt("healthPurchased", 0);
        Health = startHealth + healthBonus;
    }

    public void TakeDamage(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;
        }

        Debug.Log("Health: " + Health);
        if (Health <= 0)
        {
            Debug.Log("You lose!");
        }
    }

    public static void AddCrystals(int received)
    {
        Crystals += received;
        GameController.SaveCrystals();
    }
    public void SpendCrystals(int spent)
    {
        Crystals -= spent;
        GameController.SaveCrystals();
    }
}
