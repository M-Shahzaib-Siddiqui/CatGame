using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health, timeBeforeHeal;
    private float maxHealth, lastHit;
    public Image healthBar;

    void Start() {
        maxHealth = health;
    }

    void Update() {
        if (Time.time>lastHit+timeBeforeHeal && health<maxHealth) {
            HealthUpdate(1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<EnemyDamage>() != null) {
            GameObject enemy = collision.gameObject;
            HealthUpdate(enemy.GetComponent<EnemyDamage>().damage*-1);
            lastHit = Time.time;
        }

        if (health<=0) {Destroy(gameObject);}
    }

    void HealthUpdate(float changeInHealth) {
        health += changeInHealth;
        healthBar.fillAmount = health / maxHealth;
    }
}
