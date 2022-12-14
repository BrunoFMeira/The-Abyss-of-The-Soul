using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class GenericEnemy : MonoBehaviour
{
    IDamageable damageable;

    void Start()
    {
        damageable = GetComponent<IDamageable>();
        damageable.DeathEvent += OnDamage;
    }
    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DeathEvent -= OnDamage;
        }
    }
    private void OnDamage()
    {
        if (damageable.IsDead)
        {
            Debug.Log("Tomou dano");
            Destroy(gameObject);
        }
        else if (!damageable.IsDead)
        {
            Debug.Log("Tomou dano");
        }
    }
}