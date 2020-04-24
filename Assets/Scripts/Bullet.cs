using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int direction = 1;
    public float bulletSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection()
    {
        direction *= -1;
    }


    void Update()
    {
        rb.velocity = new Vector2(0, bulletSpeed * direction);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(direction == 1)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy>().EnemyDamage();
            }
        }

        else
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Player>().PlayerDamage();
            }
        }

        Destroy(gameObject);
    }
}
