using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearLimits : MonoBehaviour
{
    [SerializeField]
    private Vector3 axis = Vector3.up;
    [SerializeField]
    private Vector3 referencePoint = Vector3.zero;
    [SerializeField]
    private float maxDistance = 1;
    [SerializeField]
    private float minDistance = -1;

    void Update()
    {
        CheckPosition();
    }

    void CheckPosition()
    {
        float distance = Vector3.Dot(axis, transform.position - referencePoint);
        if (distance >= minDistance && distance <= maxDistance)
        {
            return;
        }
        float overstep = distance - Mathf.Clamp(distance, minDistance, maxDistance);
        transform.Translate(-overstep * axis, Space.World);
    }
}
