using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthMax = 20;
    public int health = 20;
    //public Corn corn;
    public Animator animator;
    // public GameObject border;
    public float Speed = 1f;
    float borderPosX;

    public float speedPerLevel = 0.2f;

    public float AttackTimer = 0.25f;
    public float AttackInterval = 2.5f;

    public int reward;

    // Start is called before the first frame update
    void Start()
    {
        borderPosX = Corn.singleton.transform.position.x;
    }

    // Update makes the enemy to move forward, and if it reaches the border, it stops and starts deals damage.
    void Update()
    {
        float enemyPosX = transform.position.x;

        if (enemyPosX > borderPosX)
        {
            transform.position += -transform.right * Speed * Time.deltaTime;
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
            int damage = Random.Range(4, 7);
            AttackTimer -= Time.deltaTime;
            if (AttackTimer <= 0)
            {
                AttackTimer = AttackInterval;
                Attack(damage);
            }
        }
    }

    // This method makes the enemy deal damage to the corn field.
    private void Attack(int damage                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          )
    {
        FindObjectOfType<Corn>().TakeDamage(damage);
    }

    // This method makes the enemy take damage, and if it has <= 0 health, it dies ( Die() )
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die()                                                                                                                                                                                                                   ;
        }
    }
    public void Die()
    {
        int reward = Random.Range(5, 14);
        Corn.AddCrystals(reward);
        Destroy(gameObject);
    }
}
