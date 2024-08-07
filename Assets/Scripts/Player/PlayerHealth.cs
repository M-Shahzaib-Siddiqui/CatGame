using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health, timeBeforeHeal;
    private float maxHealth, lastHit;
    public Image healthBar, healthBarEdge;

    void Start() {
        maxHealth = health;
    }

    void Update() {
        if (Time.time>lastHit+timeBeforeHeal && health<maxHealth) {
            HealthUpdate(1);
        }
        if (health==maxHealth) {healthBarEdge.color = new Color(healthBar.color.r, healthBar.color.b, healthBar.color.g, 255f);}
        else {healthBarEdge.color = healthBarEdge.color = new Color(healthBar.color.r, healthBar.color.b, healthBar.color.g, 0f);}
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
