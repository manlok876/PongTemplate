using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(BoxCollider2D))]
public class WallSettings : MonoBehaviour
{
    #region Visual
    private SpriteRenderer spriteRenderer = null;
    void UpdateVisual()
    {
        spriteRenderer.transform.localScale = boxCollider.size;
        spriteRenderer.transform.localPosition = boxCollider.offset;
    }
    #endregion

    #region Physics
    private BoxCollider2D boxCollider = null;
    // Other physics are configured in field setting for now
    #endregion

    #region General
    void Awake()
    {
        UpdateRefs();
    }

    void UpdateRefs()
    {
        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }
    void Update()
    {
        UpdateRefs();
        UpdateVisual();
    }
    #endregion
}
