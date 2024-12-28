using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public override bool CanMove(int targetRow, int targetCol)
    {
        // 边界检查
        if (targetRow < 1 || targetRow > 8 || targetCol < 1 || targetCol > 8)
        {
            return false;
        }
        
        // 合法移动判定
        if (targetRow == row || targetCol == col)
        {
            // 如果中途存在棋子，则判定为失效
            if (targetRow == row)
            {
                if (targetCol > col)
                {
                    for (int i = col; i <= targetCol; i++)
                    {
                        var targetCell = GameObject.Find("GameManager").GetComponent<GameManager>()
                            .board[row - 1, i - 1].GetComponent<Cell>();
                        if (targetCell.HasPiece()) return false;
                    }
                    // 中途没有阻挡，进行吃子判定
                    var targetPositionCell = GameObject.Find("GameManager").GetComponent<GameManager>()
                        .board[targetRow - 1, targetCol - 1].GetComponent<Cell>();
                    if (targetPositionCell.HasPiece() && targetPositionCell.currentPiece.GetComponent<Piece>().whiteSide != whiteSide) targetPositionCell.capturePiece();
                    return true;
                }
            }
        }

        return false;
    }
}
