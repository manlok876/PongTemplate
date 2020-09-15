using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRules : ScoringRules
{
    [SerializeField]
    private ScoringZone player1ScoringZone = null;
    [SerializeField]
    private ScoringZone player2ScoringZone = null;

    void Awake()
    {
        player1ScoringZone.OnScored += () => { PlayerScored(0); };
        player2ScoringZone.OnScored += () => { PlayerScored(1); };
    }
}
