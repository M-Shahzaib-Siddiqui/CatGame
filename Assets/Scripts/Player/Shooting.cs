using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce, fireRate, numOfBullets, spread, bulletDamage;
    private float nextShot, spreadIncrement, startAngle, bulletAngle;


    void Start()
    {
        nextShot = fireRate;
        spreadIncrement = spread/(numOfBullets-1);
        startAngle = spread/2 * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>nextShot) {
            Shoot();
            nextShot = Time.time+fireRate;
        }
    }

    void Shoot() {
        for (int x=0; x<(numOfBullets); x++) {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, (firePoint.rotation));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
