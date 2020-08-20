using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadPlayerController : MonoBehaviour
{
    [SerializeField]
    private VerticalMovement moveComponent = null;

    void Update()
    {
        if (!moveComponent)
        {
            return;
        }

        UpdateGameInput();
    }

    private void UpdateGameInput()
    {
        float inputValue = Input.GetAxis("Vertical");

        if (inputValue > 0)
        {
            moveComponent.direction = VerticalMovement.Direction.Up;
        }
        else if (inputValue < 0)
        {
            moveComponent.direction = VerticalMovement.Direction.Down;
        }
        else
        {
            moveComponent.direction = VerticalMovement.Direction.Stop;
        }
    }
}
