using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PongFieldSettings : MonoBehaviour
{
    #region Walls
    [Header("Walls")]
    [SerializeField]
    private BoxCollider2D topWall = null;
    [SerializeField]
    private BoxCollider2D bottomWall = null;
    [SerializeField]
    private BoxCollider2D leftWall = null;
    [SerializeField]
    private BoxCollider2D rightWall = null;
    #endregion

    #region FieldSettings
    [Header("Field Settings")]
    [SerializeField]
    private Vector2 fieldSize = new Vector2(10f, 10f);
    [SerializeField]
    private float wallThickness = 0.1f;
    #endregion

    #region Field
    private float fieldHalfWidth { get { return fieldSize.x / 2; } }
    private float fieldHalfHeight { get { return fieldSize.y / 2; } }
    private Vector2 fieldHalfSize { get { return fieldSize / 2; } }
    #endregion

    #region PlayerPositions
    [Header("Field Settings")]
    [SerializeField]
    private Transform firstPlayerStart = null;
    [SerializeField]
    private Transform secondPlayerStart = null;
    [SerializeField]
    private float padDistanceFromFieldEnd = 0.5f;
    [SerializeField]
    private GameObject padPrefab = null;

    void SpawnPads()
    {
        Instantiate(padPrefab, firstPlayerStart);
        Instantiate(padPrefab, secondPlayerStart);
    }
    #endregion

    void Start()
    {
        if (Application.isPlaying)
        {
            SpawnPads();
        }
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            Debug.Assert(fieldSize.x > 0 && fieldSize.y > 0, "Invalid field size!");
            Debug.Assert(padDistanceFromFieldEnd > 0 && padDistanceFromFieldEnd < fieldHalfWidth);

            UpdateWalls();
            UpdatePlayerPositions();
        }
    }

    void UpdatePlayerPositions()
    {
        UpdatePlayerPosition(firstPlayerStart, isLeft: true);
        UpdatePlayerPosition(secondPlayerStart, isLeft: false);
    }

    void UpdatePlayerPosition(Transform startPosition, bool isLeft)
    {
        if (startPosition == null)
        {
            return;
        }

        Vector2 facingDirection;
        if (isLeft)
        {
            facingDirection = Vector2.left;
        }
        else
        {
            facingDirection = Vector2.right;
        }

        startPosition.position = 
            transform.position + 
            transform.TransformVector(facingDirection * (fieldHalfWidth / 2 - padDistanceFromFieldEnd));
        //startPosition.rotation = Quaternion.LookRotation(Vector3.forward, facingDirection);
    }

    void UpdateWalls()
    {
        UpdateWall(topWall, isVertical: true, isNegative: false);
        UpdateWall(bottomWall, isVertical: true, isNegative: true);
        UpdateWall(rightWall, isVertical: false, isNegative: false);
        UpdateWall(leftWall, isVertical: false, isNegative: true);
    }

    void UpdateWall(BoxCollider2D wall, bool isVertical, bool isNegative)
    {
        if (wall == null)
        {
            return;
        }

        Vector2 directionToWall;
        Vector2 wallAxis;
        float radius;
        
        if (isVertical)
        {
            directionToWall = Vector2.up;
            wallAxis = Vector2.right;
            radius = fieldHalfHeight;
        }
        else
        {
            directionToWall = Vector2.right;
            wallAxis = Vector2.up;
            radius = fieldHalfWidth;
        }

        Vector2 wallSize;
        wallSize = directionToWall * wallThickness + wallAxis * fieldSize;

        Vector2 wallOffset = directionToWall * radius;
        if (isNegative)
        {
            wallOffset = wallOffset * -1;
        }

        PlaceWall(wall, wallSize, wallOffset);
    }

    void PlaceWall(BoxCollider2D wall, Vector2 size, Vector3 localOffset)
    {
        if (wall == null)
        {
            return;
        }

        float halfThickness = wallThickness / 2;

        wall.size = size;
        wall.transform.localPosition = localOffset;
        wall.offset = halfThickness * localOffset.normalized;
    }
}
