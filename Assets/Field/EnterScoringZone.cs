﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScoringZone : ScoringZone
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Score();
        }
    }
}
