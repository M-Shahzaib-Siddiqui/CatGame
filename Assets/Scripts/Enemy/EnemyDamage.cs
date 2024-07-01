using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float health,damage;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Bullet>() != null) {
            GameObject player = GameObject.Find("Player");
            health -= player.GetComponent<Shooting>().bulletDamage;
        }
        if (health<=0) {Destroy(gameObject);}
    }
}
