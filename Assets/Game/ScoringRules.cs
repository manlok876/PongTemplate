using System;
using UnityEngine;

public class ScoringRules : ScriptableObject
{
    event Action<int> OnPlayerScored;
}
