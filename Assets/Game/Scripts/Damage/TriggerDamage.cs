using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    private int damage = 10;

    public int Damage { get => damage; set => damage = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageble = collision.GetComponent<IDamageable>();
        if (damageble != null)
        {
            damageble.TakeDamage(Damage);
        }
    }
}