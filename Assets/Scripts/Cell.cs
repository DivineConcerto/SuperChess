using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public GameObject currentPiece;
    public Color selectedColor;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        Transform boardTrasnform = transform.Find("Board");
        if (boardTrasnform != null)
        {
            _spriteRenderer = boardTrasnform.GetComponent<SpriteRenderer>();
        }
        else
        {
            Debug.Log("未查找到");
        }
    }

    public void setColor(Color color)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = color;
        }
    }

    public bool HasPiece()
    {
        return currentPiece != null;
    }

    public void capturePiece()
    {
        Destroy(currentPiece);
    }
}
