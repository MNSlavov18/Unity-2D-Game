using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newEntityData", menuName ="Data/Entyty Data/Base Data")]
public class D_entity : ScriptableObject
{
    public float maxHealth = 30f;

    public float damageHopSpeed = 3f;

    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistanse = 0.4f;
    public float groundCheachRadius = 0.3f;

    public float minADistance = 3f;
    public float maxADistance = 4f;

    public float stunResistance = 3f;
    public float stunRecovery = 2f;

    public float closeRangeActionDistanse = 1f;

    public GameObject hitParticle;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

}
