using System;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour, IDamageable
{
    SimpleFlash flash;
    public bool IsDead { get; private set; }
    public int maxLife { get; private set; }
    public int curentLife { get; private set; }
    public int Life = 10;

    public event Action DeathEvent;

    private void Awake()
    {
        flash = GetComponent<SimpleFlash>();
        maxLife = Life;
        IsDead = false;
        curentLife = maxLife;
    }

    public void TakeDamage(int damage)
    {
        if (damage >= curentLife)
        {
            IsDead = true;
        }
        flash.Flash(new Color(150f, 0f, 0f, 0.75f));
        curentLife -= damage;
        DeathEvent.Invoke();
    }
}