using System.Collections;
using UnityEngine;

public class WeaponAttack : MonoBehaviour, IWeapon
{
    [SerializeField] private float attackTime = 0.2f;
    //[SerializeField] AudioClip atkfx = null;
    [SerializeField] BoxCollider2D collider;

    public bool IsAttacking { get; private set; }

    public void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;
        IsAttacking = false;
    }

    public void Attack()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;
            collider.enabled = true;
            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
    {
        //SoundManager.instance.PlaySingle(atkfx);
        yield return new WaitForSeconds(attackTime);
        collider.enabled = false;
        IsAttacking = false;
        yield return null;
    }
}
