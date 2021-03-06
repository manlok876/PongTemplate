﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLimits : MonoBehaviour
{
    [SerializeField]
    public float maxY = 1;
    [SerializeField]
    public float minY = -1;

    void Update()
    {
        CheckPosition();
    }

    void CheckPosition()
    {
        float height = transform.position.y;
        if (height >= minY && height <= maxY)
        {
            return;
        }
        float overstep = height - Mathf.Clamp(height, minY, maxY);
        transform.Translate(-overstep * Vector3.up, Space.World);
    }
}
