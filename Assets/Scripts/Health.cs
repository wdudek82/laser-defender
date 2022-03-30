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

    [SerializeField]
    private bool applyCameraShake;

    private CameraShake _cameraShake;
    private AudioPlayer _audioPlayer;

    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();

        if (Camera.main == null) return;
        _cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var damageDealer = col.GetComponent<DamageDealer>();
        if (damageDealer == null) return;
        TakeDamage(damageDealer.Damage);
        PlayHitEffect();
        _audioPlayer.PlayDamageClip();
        if (applyCameraShake)
        {
            ShakeCamera();
        }

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

    private void ShakeCamera()
    {
        _cameraShake.Play();
    }

    private void PlayHitEffect()
    {
        if (hitEffect == null) return;
        var instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
        var main = instance.main;
        Destroy(instance.gameObject, main.duration + main.startLifetime.constantMax);
    }
}
