using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knight : Piece
{
    public override bool CanMove(int targetRow, int targetCol)
    {
        // 边界检查
        if (targetRow < 1 || targetRow > 8 || targetCol < 1 || targetCol > 8)
        {
            return false;
        }
        // 合法位置检查
        if (targetRow == row + 1 || targetRow == row - 1)
        {
            if (targetCol == col + 2 || targetCol == col - 2)
            {
                // 合法吃子检查
                var targetPositionCell = GameObject.Find("GameManager").GetComponent<GameManager>()
                    .board[row - 1, col - 1].GetComponent<Cell>();
                if (targetPositionCell.HasPiece() &&
                    targetPositionCell.currentPiece.GetComponent<Piece>().whiteSide != whiteSide)
                {
                    targetPositionCell.capturePiece();
                    return true;
                }
                    
            };
        }

        if (targetCol == col + 1 || targetCol == col - 1)
        {
            if (targetRow == row + 2 || targetRow == row - 2)
            {
                // 合法吃子检查
                var targetPositionCell = GameObject.Find("GameManager").GetComponent<GameManager>().board[row-1,col-1].GetComponent<Cell>();
                if (targetPositionCell.HasPiece() &&
                    targetPositionCell.currentPiece.GetComponent<Piece>().whiteSide != whiteSide)
                {
                    targetPositionCell.capturePiece();
                    return true;
                }
            }
        }
        return false;
    }

    
    
    
}
