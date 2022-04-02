using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField]
    private AudioClip shootingClip;

    [SerializeField]
    [Range(0f, 1f)]
    private float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField]
    private AudioClip damageClip;

    [SerializeField]
    [Range(0f, 1f)]
    private float damageVolume = 1f;

    private static AudioPlayer _instance;

    // public AudioPlayer GetInstance()
    // {
    //     return _instance;
    // }

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        // Alternative way of creating singleton
        // var instanceCount = FindObjectsOfType(GetType()).Length;
        // if (instanceCount > 1)
        if (_instance != null)
        {
            GameObject o;
            (o = gameObject).SetActive(false);
            Destroy(o);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    private static void PlayClip(AudioClip clip, float volume)
    {
        if (clip == null || Camera.main == null) return;
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }
}
