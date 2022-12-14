using System.Collections;
using UnityEngine;

public class Boss1Conditional : MonoBehaviour
{
    public Animator boss1Anim;
    public BoxCollider2D colliderSmash;
    //public IDamageble damageble;

    public void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        boss1Anim.SetTrigger("IsPreSmash");
        yield return new WaitForSeconds(0.5f);
        boss1Anim.ResetTrigger("IsPreSmash");
        boss1Anim.SetTrigger("IsSmash");
        colliderSmash.enabled = true;
        yield return new WaitForSeconds(0.217f);
        boss1Anim.ResetTrigger("IsSmash");
        colliderSmash.enabled = false;
        boss1Anim.SetTrigger("IsRecoSmash");
        yield return new WaitForSeconds(0.667f);
        boss1Anim.ResetTrigger("IsRecoSmash");
        boss1Anim.SetTrigger("EndSmash");
        yield return new WaitForSeconds(1f);

    }

}
