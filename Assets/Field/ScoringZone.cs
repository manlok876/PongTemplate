using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringZone : MonoBehaviour
{
    public event Action OnScored;

    protected void Score()
    {
        if (OnScored != null)
        {
            OnScored.Invoke();
        }
    }
}
