﻿using System;
using UnityEngine;

public class ScoringRules : MonoBehaviour
{
    public event Action<int> OnPlayerScored;

    protected void PlayerScored(int playerIndex)
    {
        if (OnPlayerScored != null)
        {
            OnPlayerScored.Invoke(playerIndex);
        }
    }
}
