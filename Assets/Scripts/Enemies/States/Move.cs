using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Move : State
{
    protected D_Move stateDeta;

    protected bool isDetectingWall;
    protected bool isDetactingLedge;
    protected bool isPlayerInMinAgroRange;

    public Move(Entity entity, FineteStateMachine stateMachine, string animBoolName, D_Move stateDeta) : base(entity, stateMachine, animBoolName)
    {
       this.stateDeta = stateDeta;
    }

    public override void DoChacks()
    {
        base.DoChacks();

        isDetactingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerInMinAgroRange = entity.ChechPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVel(stateDeta.movementSpeed);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    
    }
}
