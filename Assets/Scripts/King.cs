using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public override bool CanMove(int targetRow, int targetCol)
    {
        // 边界检查
        if (targetRow < 1 || targetRow > 8 || targetCol < 1 || targetCol > 8)
        {
            return false;
        }
        
        // 合法移动
        if (targetRow <= row + 1 && targetRow >= row - 1 && targetCol <= col + 1 && targetCol >= col + 1)
        {
            // 进行吃子判定和将军判定
            return true;
        }

        return false;
    }
}
