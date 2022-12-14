using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class MirrorController : MonoBehaviour
{
    IDamageable damageable;
    [SerializeField] GameObject Item;


    void Awake()
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
            Destroy(gameObject);
            Item.SetActive(true);

        }
    }
}
