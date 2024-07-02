using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float health,damage;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Bullet>() != null) {
            float gunDamage = FindObjectOfType<Shooting>().bulletDamage;
            health -= gunDamage;
        }
        if (health<=0) {Destroy(gameObject);}
    }
}
