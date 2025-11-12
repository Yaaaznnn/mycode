using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // --- Configuration ---
    public Transform firePoint;     // The position where the bullet spawns
    public GameObject bulletPrefab; // The bullet asset we want to shoot

    // Update is called once per frame
    void Update()
    {
        // Check for the "Fire1" button (Default is Left Ctrl or Mouse Click)
        // You can also use Input.GetKeyDown(KeyCode.F) if you prefer.
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Logic to spawn the bullet
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

