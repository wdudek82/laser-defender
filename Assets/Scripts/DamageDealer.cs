using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    public int Damage => damage;

    public void Hit()
    {
        Destroy(gameObject);
    }
}
