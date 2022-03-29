using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 50;

    [SerializeField]
    private ParticleSystem hitEffect;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var damageDealer = col.GetComponent<DamageDealer>();
        if (damageDealer == null) return;

        TakeDamage(damageDealer.Damage);
        PlayHitEffect();
        damageDealer.Hit();
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void PlayHitEffect()
    {
        Debug.Log("should play hit effect?");
        if (hitEffect == null) return;
        Debug.Log("hit effect play");
        var instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
        var main = instance.main;
        Destroy(instance.gameObject, main.duration + main.startLifetime.constantMax);
    }
}
