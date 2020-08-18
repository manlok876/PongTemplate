using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadPlayerController : MonoBehaviour
{
    private VerticalMovement moveComponent = null;

    void Awake()
    {
        moveComponent = GetComponent<VerticalMovement>();
    }

    void Update()
    {
        if (!moveComponent)
        {
            return;
        }

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
