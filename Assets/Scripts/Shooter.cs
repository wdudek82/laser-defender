using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float projectileSpeed = 10f;

    [SerializeField]
    private float projectileLifetime = 5f;

    [SerializeField]
    private float baseFireRate = 0.2f;

    [Header("AI")]
    [SerializeField]
    private float firingRateVariance;

    [SerializeField]
    private float minFiringRate = 0.1f;

    [SerializeField]
    private bool useAI;

    [HideInInspector]
    public bool isFiring;

    private Coroutine _firingCoroutine;

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && _firingCoroutine == null)
        {
            _firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && _firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            var instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            var rigidBody = instance.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                rigidBody.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);
            yield return new WaitForSecondsRealtime(TimeToNextProjectile());
        }
    }

    private float TimeToNextProjectile()
    {
        var result = Random.Range(baseFireRate - firingRateVariance,
            baseFireRate + firingRateVariance);
        return Mathf.Clamp(result, minFiringRate, float.MaxValue);
    }
}
