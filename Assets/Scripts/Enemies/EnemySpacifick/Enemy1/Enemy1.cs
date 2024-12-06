using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_playerDetectedState playerDetectedState { get; private set; }
    public E1_Charge chargeState{ get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }
    public E1_MelleAttackState melleAttackState { get; private set; }
    public E1_DeadState deadState { get; private set; }

    public E1_stunState stunState { get; private set; }
    [SerializeField]
    private D_Idle idleStateData;
    [SerializeField]
    private D_Move moveStateData;
    [SerializeField]
    private D_playerDetacted playerDetectedData;
    [SerializeField]
    private D_Charge chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MelleAttack melleAttackDeta;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deatStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_playerDetectedState(this, stateMachine, "playerD", playerDetectedData, this);
        chargeState = new E1_Charge(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMachine, "lFP", lookForPlayerStateData, this);
        melleAttackState = new E1_MelleAttackState(this, stateMachine, "MA", meleeAttackPosition, melleAttackDeta, this);
        stunState = new E1_stunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E1_DeadState(this, stateMachine, "dead", deatStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, melleAttackDeta.attackRadius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
        }
        else if (isStunned && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }

   
    }
}
