using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMelleAttakStateData", menuName = "Data/State Data/Melle Attack State")]
public class D_MelleAttack : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;

    public LayerMask wahtIsPlayer;
}
