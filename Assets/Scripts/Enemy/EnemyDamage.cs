using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float health;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Bullet(Clone)") {health-=50;}
        if (health<=0) {Destroy(gameObject);}
    }
}
