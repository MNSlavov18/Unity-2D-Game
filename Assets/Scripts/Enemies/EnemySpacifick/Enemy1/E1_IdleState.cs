using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : Idle
{
    private Enemy1 enemy;
    public E1_IdleState(Entity entity, FineteStateMachine stateMachine, string animBoolName, D_Idle stataDate, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stataDate)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else  if (isIDleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
