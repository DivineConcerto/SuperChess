using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override bool CanMove(int targetRow, int targetCol)
    {
        // 边界检查
        if (targetRow < 1 || targetRow > 8 || targetCol < 1 || targetCol > 8)
        {
            return false;
        }
        
        // 白方的子
        if (whiteSide)
        {
            // 合法前进
            if (targetRow == row && targetCol == col + 1)
            {
                // 如果前方没有棋子
                var foreingCell = GameObject.Find("GameManager").GetComponent<GameManager>().board[row-1,col-1];
                // 如果被阻挡了，就返回false
                if (foreingCell.GetComponent<Cell>().HasPiece()) return false;
                return true;
            }
        
            // 合法吃子
            if ((targetRow == row + 1 || targetRow == row - 1) && (targetCol == col + 1))
            {
                var targetPosition = GameObject.Find("GameManager").GetComponent<GameManager>().board[row-1,col-1];
                if (targetPosition.GetComponent<Cell>().HasPiece() && targetPosition.GetComponent<Cell>().currentPiece.GetComponent<Piece>().whiteSide != whiteSide)
                {
                    targetPosition.GetComponent<Cell>().capturePiece();
                    return true;
                }
            }
        }
        
        // 黑方的子
        else
        {
            // 合法前进
            if (targetRow == row && targetCol == col - 1)
            {
                // 如果前方没有棋子
                var foreingCell = GameObject.Find("GameManager").GetComponent<GameManager>().board[row-1,col-1];
                // 如果被阻挡了，就返回false
                if (foreingCell.GetComponent<Cell>().HasPiece()) return false;
                return true;
            }
        
            // 合法吃子
            if ((targetRow == row + 1 || targetRow == row - 1) && (targetCol == col - 1))
            {
                var targetPosition = GameObject.Find("GameManager").GetComponent<GameManager>().board[row-1,col-1];
                if (targetPosition.GetComponent<Cell>().HasPiece()&& targetPosition.GetComponent<Cell>().currentPiece.GetComponent<Piece>().whiteSide != whiteSide)
                {
                    targetPosition.GetComponent<Cell>().capturePiece();
                    return true;
                }
            }
        }
        return false;
    }
    
}
