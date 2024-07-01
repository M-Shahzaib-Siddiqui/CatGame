using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce, fireRate, nextShot, bulletDamage;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>nextShot) {
            Shoot();
            nextShot = Time.time+fireRate;
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
