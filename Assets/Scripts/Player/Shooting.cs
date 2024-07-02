using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce, fireRate, numOfBullets, spread, bulletDamage, bulletHealth, bulletTime;
    private float nextShot, spreadIncrement, startAngle;
    Vector3 rot;


    void Start()
    {
        nextShot = 0;
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
        if (numOfBullets==1) {
            rot = firePoint.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y, rot.z+90f);
            Instantiate(bulletPrefab).GetComponent<Bullet>().SpawnBullet(firePoint.position, Quaternion.Euler(rot), bulletForce);
            return;
        }

        for (int x=0; x<(numOfBullets); x++) {
            rot = firePoint.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y, rot.z+startAngle+(spreadIncrement*x)+90f);
            Instantiate(bulletPrefab).GetComponent<Bullet>().SpawnBullet(firePoint.position, Quaternion.Euler(rot), bulletForce);
        }
    }
}
