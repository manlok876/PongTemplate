using System;
using UnityEngine;

public class ScoringRules : ScriptableObject
{
    public event Action<int> OnPlayerScored;
}
