using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float projectileSpeed = 10f;

    [SerializeField]
    private float projectileLifetime = 5f;

    [SerializeField]
    private float fireRate = 0.2f;

    public bool isFiring;

    private Coroutine _firingCoroutine;

    void Start()
    {
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
            yield return new WaitForSecondsRealtime(fireRate);
        }
    }
}
