using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 30;

    private Vector2 velocity;

    public void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        
        //Since our transform.rotation was set we can use out 'forward' vector (right in 2d) as our trajectory
        velocity = transform.right.normalized * MovementSpeed;
    }
    public void Update()
    {

        // Move the Bullet forwards at a constant rate.
        Vector2 nextPosition = (Vector2)transform.position + (velocity * Time.deltaTime);
        // Set the transform Position to the new position this frame.
        transform.position = nextPosition;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name != "Bullet(Clone)") {Destroy(gameObject);}
    }
}
