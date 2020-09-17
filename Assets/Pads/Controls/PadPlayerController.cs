using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadPlayerController : MonoBehaviour
{
    [Serializable]
    public enum Player
    {
        None,
        Player1,
        Player2,
        AI
    }

    [SerializeField]
    private Player player = Player.None;
    [SerializeField]
    private VerticalMovement moveComponent = null;
    private string axisName
    {
        get
        {
            if (player == Player.Player1)
            {
                return "Player1Vertical";
            }
            else if (player == Player.Player2)
            {
                return "Player2Vertical";
            }
            else
            {
                return "";
            }
        }
    }

    void Start()
    {
        if (moveComponent == null)
        {
            moveComponent = GetComponent<VerticalMovement>();
        }
    }

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
        if (player == Player.None)
        {
            return;
        }
        float inputValue = Input.GetAxis(axisName);

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
