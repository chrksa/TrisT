using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBlock : MonoBehaviour
{
    public Board board;
    //public int[,] gridTiles = new int[20, 20];
    int width;
    int height;
    private bool gameOver;

    public void Init(Board boardIn)
    {
        this.board = boardIn;
        this.gameOver = false;
        width = -board.xMin + board.xMax;
        height= -board.yMin + board.yMax;
    }

    public void DrawPlacedPieces()
    {
        Vector3Int pos = new Vector3Int(0, 0, 0);
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                pos.x = i - 10;
                pos.y = j - 10;
                board.tilemap.SetTile(pos, board.shapes[board.tilegrid[i, j]].tile);
            }
        }
    }

    // Start is called once before the first frame update
    void Start()
    {
        

    }

    private bool checkForFullRows()
    {
        return false;
    }

    //deletes a Row in grid and moves the Tiles above one field down
    private void deleteRowAndShift(int rowY)
    {
        deleteRow(rowY);
        for (int y = rowY; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //grid[x, y] = grid[x, y + 1];
            }
        }
    }
    private void deleteRow(int rowY)
    {
        for (int x = 0; x < width; x++)
        {
            //grid[x, rowY] = Shape.NULL;
        }
    }

    public bool IsOver() { return gameOver; }
}