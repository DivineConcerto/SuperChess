using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    [Header("当前位置")] 
    public int row;
    public int col;


    [Header("棋子属性")]
    public bool whiteSide = true;

    public string type = "";

    public abstract bool CanMove(int targetRow,int targetCol);
}
