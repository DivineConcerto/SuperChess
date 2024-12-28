using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
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
        
        // 合法移动检查
        if (targetRow - row == targetCol - col)
        {
            // 中途是否有阻挡
            if (targetRow > row)
            {
                for (int i = row+1; i <= targetRow; i++)
                {
                    var targetPositionCell = GameObject.Find("GameManager").GetComponent<GameManager>()
                        .board[i-1, col + (i - row)-1].GetComponent<Cell>();

                    if (targetPositionCell.HasPiece()) return false;

                }
                // 吃子检查
                var targetCell = GameObject.Find("GameManager").GetComponent<GameManager>()
                    .board[targetRow - 1, targetCol - 1].GetComponent<Cell>();
                if (targetCell.HasPiece() && targetCell.currentPiece.GetComponent<Piece>().whiteSide != whiteSide) targetCell.capturePiece();
                return true;
            }

            if (targetRow < row)
            {
                for (int i = targetRow + 1; i <= row; i++)
                {
                    var targetPositionCell = GameObject.Find("GameManager").GetComponent<GameManager>().board[i-1,col+(i-targetRow)-1].GetComponent<Cell>();
                    if (targetPositionCell.HasPiece()) return false;
                }
                // 吃子检查
                var targetCell = GameObject.Find("GameManager").GetComponent<GameManager>()
                    .board[targetRow - 1, targetCol - 1].GetComponent<Cell>();
                if (targetCell.HasPiece() && targetCell.currentPiece.GetComponent<Piece>().whiteSide != whiteSide) targetCell.capturePiece();
                return true;
            }
        }

        return false;
    }
}
