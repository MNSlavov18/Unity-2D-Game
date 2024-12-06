using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected FineteStateMachine stateMachine;
    protected Entity entity;

    protected float startTime;

    protected string animBoolName;

    public State(Entity entity, FineteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        DoChacks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        DoChacks();
    }


    public virtual void DoChacks()
    {
        
    }

}
