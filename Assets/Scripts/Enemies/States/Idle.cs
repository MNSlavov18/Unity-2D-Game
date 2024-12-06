using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Idle : State
{
    protected D_Idle stataDate;

    protected bool flipAfterIdle;
    protected bool isIDleTimeOver;
    protected bool isPlayerInMinAgroRange;

    protected float idleTime;

    public Idle(Entity entity, FineteStateMachine stateMachine, string animBoolName, D_Idle stataDate) : base(entity, stateMachine, animBoolName)
    {
        this.stataDate = stataDate;
    }

    public override void DoChacks()
    {
        base.DoChacks();

        isPlayerInMinAgroRange = entity.ChechPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVel(0f);
        isIDleTimeOver = false;
        SetRandIdleTime();

    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + idleTime)
        {
            isIDleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }

    public void SetFlifAfterAdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    private void SetRandIdleTime ()
    {
        idleTime = Random.Range(stataDate.minIdleTime, stataDate.maxIdleTime);
    }
}

