using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

[ExecuteAlways]
public class PongPadGizmos : MonoBehaviour
{
    private VerticalLimits limits = null;
    [SerializeField]
    private Color gizmoColor = Color.white;
    [SerializeField]
    private float borderWidth = 0.2f;
    [SerializeField]
    [Tooltip("Specifies length of line drawn when limits are not attached")]
    private float maxRadius = 100;

    void Awake()
    {
        limits = GetComponent<VerticalLimits>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        Vector3 top = transform.position;
        Vector3 bottom = transform.position;

        if (limits != null)
        {
            top.y = limits.maxY;
            bottom.y = limits.minY;
        }
        else
        {
            top.y += maxRadius;
            bottom.y -= maxRadius;
        }

        DrawPath(top, bottom);
        DrawBorders(top, bottom);
    }

    private void DrawPath(Vector3 top, Vector3 bottom)
    {
        Gizmos.DrawLine(top, bottom);
    }

    private void DrawBorders(Vector3 top, Vector3 bottom)
    {
        if (limits == null)
        {
            return;
        }

        Vector3 halfBorder = Vector3.right * borderWidth;

        Gizmos.DrawLine(top - halfBorder, top + halfBorder);
        Gizmos.DrawLine(bottom - halfBorder, bottom + halfBorder);
    }
}
