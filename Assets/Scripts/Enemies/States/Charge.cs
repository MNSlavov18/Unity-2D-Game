using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : State
{
    protected D_Charge stateData;

    protected bool isPlayerInMInAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAttack;
    public Charge(Entity entity, FineteStateMachine stateMachine, string animBoolName, D_Charge stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChacks()
    {
        base.DoChacks();

        isPlayerInMInAgroRange = entity.ChechPlayerInMinAgroRange();
        isDetectingWall = entity.CheckWall();
        isDetectingLedge = entity.CheckLedge();

        performCloseRangeAttack = entity.CheckPlayerInCloseRange();
    }

    public override void Enter()
    {
        base.Enter();
        isChargeTimeOver = false;
        entity.SetVel(stateData.chargeSpeed);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + stateData.cahrgeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
