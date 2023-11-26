using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        for (int i = 1; i < 20; i++)
        {
            for (int j = 1; j < 20; j++)
            {
                pos.x = i - 10;
                pos.y = j - 10;
                Debug.Log(pos);
                board.tilemap.SetTile(pos, board.shapes[board.tilegrid[i, j]].tile);
            }
        }
    }

    public void DrawPlayablePiece(PlayablePiece piece) 
    {
        int xPos = 0;
        int yPos = 0;
        int counter = 0;
        Vector3Int tilepos = new Vector3Int(0, 0, 0);
        for (int i = 0; i < piece.Cells.Length; i++)
        {
            xPos = piece.Cells[i].x + piece.position.x + 10;
            yPos = piece.Cells[i].y + piece.position.y + 10;
            counter++;
            Debug.Log(counter);

            Debug.Log("Pos:" + xPos + ", " + yPos);
            board.tilegrid[xPos, yPos] = (int)piece.data.shape;
        }

    } 

    // Start is called once before the first frame update
    void Start()
    {
        

    }

    //
    private void deleteRow(int rowY)
    {
        for (int x = 0; x < width; x++)
        {
            //grid[x, rowY] = Shape.NULL;
        }
    }

    public bool IsOver() { return gameOver; }
}