using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("游戏棋盘设置")]
    public GameObject gridPrefab;
    public int rows = 8;
    public int columns = 8;
    public float cellSize = 1f;
    public GameObject[,] board;

    [Header("游戏机制")] 
    public bool whiteRound = true;
    

    [Header("棋子排放区")]
    public GameObject pawn;

    public GameObject knight;
    
    public GameObject bishop;
    
    public GameObject rook;
    
    public GameObject queen;
    
    public GameObject king;

    private void Start()
    {
        DrawBoard();
    }

    public void PlacePiece()
    {
        
    }

    public void DrawBoard()
    {
        board = new GameObject[rows, columns];
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Vector3 position = new Vector3((row-4) * cellSize, (column-4) * cellSize, 0f);
                GameObject cell = Instantiate(gridPrefab, position, Quaternion.identity);
                cell.transform.parent = this.transform;
                if ((row + column) % 2 == 0) cell.GetComponent<Cell>().setColor(Color.gray);
                cell.name = "Cell [" + row + "," + column + "]";
                board[row, column] = cell;
            }
        }
    }
    
    

}
