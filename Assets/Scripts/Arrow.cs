using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public static int startDmg = 6;
    public static int dmgPerUpgrade = 2;
    public static int damage;
    public static int startSpd = 2;
    public static int spdPerUpgrade = 2;
    public static int speed;

    private void Awake()
    { 
        int dmgBonus = dmgPerUpgrade * PlayerPrefs.GetInt("dmgPurchased", 0);
        damage = startDmg + dmgBonus;

        int spdBonus = spdPerUpgrade * PlayerPrefs.GetInt("spdPurchased", 0);
        speed = startSpd + dmgBonus;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
