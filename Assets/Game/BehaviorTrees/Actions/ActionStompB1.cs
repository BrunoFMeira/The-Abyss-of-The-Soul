using System.Collections;
using System.Collections.Generic;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("Game/BossMoves")]
public class ActionStompB1 : BasePrimitiveAction
{
    [InParam("Conditional")]
    public Boss1Conditional bossConditional;
    private bool AttackEnd;

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("ActionStompB1: Start");
        AttackEnd = false;
        bossConditional.Attack();
        AttackEnd = true;
    }

    public override TaskStatus OnUpdate()
    {
        Debug.Log("ActionStompB1: OnUpdate");
        if(AttackEnd)
        {
            return TaskStatus.COMPLETED;
        }else
        {
            return TaskStatus.RUNNING;
        }

    }


}
