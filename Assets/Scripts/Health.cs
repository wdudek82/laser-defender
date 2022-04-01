using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer;

    [SerializeField]
    private int health = 50;

    [SerializeField]
    private int score = 50;

    [SerializeField]
    private ParticleSystem hitEffect;

    [SerializeField]
    private bool applyCameraShake;

    private CameraShake _cameraShake;
    private AudioPlayer _audioPlayer;
    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();

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

    public int GetHealth()
    {
        return health;
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health > 0) return;
        Die();
    }

    private void Die()
    {
        if (!isPlayer)
        {
            _scoreKeeper.UpdateScoreWithValue(score);
        }
        Destroy(gameObject);

        if (isPlayer)
        {
            FindObjectOfType<LevelManager>().LoadGameOver();
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
