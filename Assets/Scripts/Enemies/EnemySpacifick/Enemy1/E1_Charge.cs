using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_Charge : Charge
{
    private Enemy1 enemy;

    public E1_Charge(Entity entity, FineteStateMachine stateMachine, string animBoolName, D_Charge stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChacks()
    {
        base.DoChacks();
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

        if (performCloseRangeAttack)
        {
            stateMachine.ChangeState(enemy.melleAttackState);
        }
        else if (!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else   if (isChargeTimeOver)
        {
            if (isPlayerInMInAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
