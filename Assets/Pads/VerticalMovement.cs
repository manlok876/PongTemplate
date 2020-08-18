using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [Serializable]
    public enum Direction
    {
        Stop,
        Up,
        Down
    }

    #region Movement
    [Header("Movement")]
    [SerializeField]
    private float speed = 1f;
    #endregion

    [NonSerialized]
    public Direction direction;

    void FixedUpdate()
    {
        if (direction == Direction.Stop)
        {
            return;
        }

        Vector3 directionVector = Vector3.zero;
        if (direction == Direction.Up)
        {
            directionVector = Vector3.up;
        }
        else if (direction == Direction.Down)
        {
            directionVector = Vector3.down;
        }

        transform.Translate(directionVector * speed * Time.fixedDeltaTime);
    }
}
