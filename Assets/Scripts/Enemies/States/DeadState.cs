using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    protected D_DeadState stateData;

    public DeadState(Entity entity, FineteStateMachine stateMachine, string animBoolName, D_DeadState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChacks()
    {
        base.DoChacks();
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(stateData.deadBloodParticle, entity.aliveGO.transform.position, stateData.deadBloodParticle.transform.rotation);
        GameObject.Instantiate(stateData.deadChinkParticle, entity.aliveGO.transform.position, stateData.deadChinkParticle.transform.rotation);

        entity.gameObject.SetActive(false);
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
