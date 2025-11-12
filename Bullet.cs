using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // --- Configuration ---
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb; // Reference to the Rigidbody2D on the bullet

    void Start()
    {
        // When the bullet spawns, make it fly forward immediately
        // "transform.right" means the red X-axis of the bullet (forward in 2D)
        rb.velocity = transform.right * speed;
    }

    // This detects when the bullet hits something
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // 1. Ignore the Player (so we don't shoot ourselves)
        if (hitInfo.CompareTag("Player"))
        {
             return;
        }

        // 2. Check if we hit an Enemy
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // 3. Destroy the bullet immediately upon hitting anything
        // (Walls, ground, or enemies)
        Destroy(gameObject);
    }
}

