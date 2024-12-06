using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : State
{
    protected D_LookForPlayer stateData;

    protected bool isPlayerInMinAgroRnage;
    protected bool isAllTurnsDone;
    protected bool isAllTurnTimeDone;
    protected bool turnImediately;

    protected float lastTurnTIme;

    protected int amoutOfTurnsDone;
    public LookForPlayerState(Entity entity, FineteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChacks()
    {
        base.DoChacks();

        isPlayerInMinAgroRnage = entity.ChechPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        isAllTurnsDone = false;
        isAllTurnTimeDone = false;

        lastTurnTIme = startTime;
        amoutOfTurnsDone = 0;

        entity.SetVel(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (turnImediately)
        {
            entity.Flip();
            lastTurnTIme = Time.time;
            amoutOfTurnsDone++;
            turnImediately = false;
        }
        else if (Time.time >= lastTurnTIme + stateData.timesBetweenTurns && !isAllTurnsDone)
        {
            entity.Flip();
            lastTurnTIme = Time.time;
            amoutOfTurnsDone++;
        }

        if (amoutOfTurnsDone >= stateData.amountOfTurns)
        {
            isAllTurnsDone = true;
        }

        if (Time.time >= lastTurnTIme + stateData.timesBetweenTurns && isAllTurnsDone)
        {
            isAllTurnTimeDone = true;
        }
         
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetTurnImideietely(bool flip)
    {
        turnImediately = flip;
    }
}
