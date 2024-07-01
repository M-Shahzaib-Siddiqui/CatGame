using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<EnemyDamage>() != null) {
            GameObject enemy = collision.gameObject;
            health -= enemy.GetComponent<EnemyDamage>().damage;
        }

        if (health<=0) {Destroy(gameObject);}
    }
}
