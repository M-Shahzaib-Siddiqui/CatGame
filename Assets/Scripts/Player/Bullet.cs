using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector2 velocity;
    float health, timeAlive, deathTime;

    public void SpawnBullet(Vector3 position, Quaternion rotation, float force)
    {
        transform.position = position;
        transform.rotation = rotation;
        
        //Since our transform.rotation was set we can use out 'forward' vector (right in 2d) as our trajectory
        velocity = transform.right.normalized * force;
        health = FindObjectOfType<Shooting>().bulletHealth;
        timeAlive = FindObjectOfType<Shooting>().bulletTime;
        deathTime = Time.time + timeAlive;

    }
    public void Update()
    {

        // Move the Bullet forwards at a constant rate.
        Vector2 nextPosition = (Vector2)transform.position + (velocity * Time.deltaTime);
        // Set the transform Position to the new position this frame.
        transform.position = nextPosition;

        if (Time.time >= deathTime) {Destroy(gameObject);}
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy(Clone)") {
            health-=1;
            }

        if (health<=0) {Destroy(gameObject);}
    }
}
