using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MelleAttackState : MelleAttackState
{
    private Enemy1 enemy;

    public E1_MelleAttackState(Entity entity, FineteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MelleAttack stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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

    public override void FinnishAttack()
    {
        base.FinnishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimFinished)
        {
            if (isPlayerInMinAgroRange)
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

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
