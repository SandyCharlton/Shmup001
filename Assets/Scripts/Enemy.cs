using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float enemySpeedX;
    public float enemySpeedY;
    public bool canShoot;
    public float fireRate;
    public float enemyHealth;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(enemySpeedX, enemySpeedY * -1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<Player>().PlayerDamage();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void EnemyDamage()
    {
        enemyHealth--;
        if(enemyHealth <= 0)
        {
            Die();
        }
    }
}
