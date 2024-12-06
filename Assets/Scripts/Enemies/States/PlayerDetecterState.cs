using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetecterState : State
{
    protected D_playerDetacted stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAttack;
    protected bool performCloseRangeAttack;
   

    public PlayerDetecterState(Entity entity, FineteStateMachine stateMachine, string animBoolName, D_playerDetacted stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChacks()
    {
        base.DoChacks();

        isPlayerInMinAgroRange = entity.ChechPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.ChechPlayerInMaxAgroRange();

         performCloseRangeAttack = entity.CheckPlayerInCloseRange();
    }

    public override void Enter()
    {
        base.Enter();
        performLongRangeAttack = false;

        entity.SetVel(0f);
  
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + stateData.longRangeActionTime)
        {
            performLongRangeAttack = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
  
    }
}
