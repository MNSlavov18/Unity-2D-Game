﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newLookForPlayerStateStateData", menuName = "Data/State Data/Look for player State")]
public class D_LookForPlayer : ScriptableObject
{
    public int amountOfTurns = 2;
    public float timesBetweenTurns = 0.75f;
} 
