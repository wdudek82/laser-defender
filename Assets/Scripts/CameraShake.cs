using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private float shakeDuration = 1f;

    [SerializeField]
    private float shakeMagnitude = 0.5f;

    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        var elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            transform.position = _initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = _initialPosition;
    }
}
