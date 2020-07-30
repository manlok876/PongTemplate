using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    #region Movement
    [Header("Movement")]
    [SerializeField]
    private float speed = 1f;
    #endregion

    [SerializeField]
    private KeyCode upKey;
    [SerializeField]
    private KeyCode downKey;

    void FixedUpdate()
    {
        if (Input.GetKey(upKey))
        {
            transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(downKey))
        {
            transform.Translate(-Vector3.up * speed * Time.fixedDeltaTime);
        }
    }
}
