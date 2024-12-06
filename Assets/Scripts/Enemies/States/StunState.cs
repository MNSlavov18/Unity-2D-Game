using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : State
{

    protected D_StunState stateData;

    protected bool isStunTimeOver;

    protected bool isGrounded;

    protected bool isMovementStoped;

    protected bool performCloseRangeAttack;

    protected bool isPlayerInMinAgroRange;

    public StunState(Entity entity, FineteStateMachine stateMachine, string animBoolName, D_StunState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChacks()
    {
        base.DoChacks();

        isGrounded = entity.ChaeckGround();
        performCloseRangeAttack = entity.CheckPlayerInCloseRange();
        isPlayerInMinAgroRange = entity.ChechPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        isStunTimeOver = false;
        isMovementStoped = false;
        entity.SetVel(stateData.stunKnockbackspeed, stateData.stunKnokbackAngle, entity.lastDamageDirection);
    }

    public override void Exit()
    {
        base.Exit();
        entity.ResetSunResist();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + stateData.stunTime)
        {
            isStunTimeOver = true;
        }

        if (isGrounded && Time.time >= startTime + stateData.stunKnockBAckTime && !isMovementStoped)
        {
            isMovementStoped = true;
            entity.SetVel(0f);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
