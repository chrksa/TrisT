using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacedPiece : MonoBehaviour
{
    [SerializeField]public Board board;
    public Shape[,] grid;

    const int xMax = 10;
    const int xMin = -10;
    const int yMax = 10;
    const int yMin = -10;
    const int maxTileHeight = 4;
    const int posZ = 0;
    int width;
    int height;


    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        width = xMin + xMax;
        height = yMin + yMax;
        grid= new Shape[width, height + maxTileHeight];
        gameOver= false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //return true if there is any error 
    public bool addTile(int x, int y, Shape shape) {
        if (xMin <= x && x <= xMax && yMin <= y) {
            if (y > yMax && y <= (yMax + maxTileHeight)) {
                gameOver = true;
                return false;
            }

            return false;
        }
        Debug.LogError("Du hast versucht ein Tile hinzuzufügen, das sich außerhalb der gelegten Grenzen befindet");
        return true;
    }

    private void drawPlacedTiles() {
        Tilemap map = board.tilemap;
         
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Vector3Int pos = new Vector3Int(x + xMin, y + yMin, posZ);
                map.SetTile(pos, shapeToTile(grid[x, y]));

            }
        }

    }
    public Tile shapeToTile(Shape shape) {
        if (shape == Shape.NULL) return null;
        ShapeData[] shapes= board.shapes;
        for (int i = 0; i < shapes.Length; i++) {
            if (shapes[i].shape == shape) return shapes[i].tile;
        }
        return null;
    }
    //checks out all rows, return true if a row is full
    private bool checkForFullRows() {
        for (int y = 0; y < height; y++) {
            int rowCounter = 0;
            for (int x = 0; x < width; x++) {
                if (grid[x, y] != Shape.NULL) { 
                    rowCounter++;
                }
            }
            if(rowCounter == width)return true;
        }
        return false;
    }

    //deletes a Row in grid and moves the Tiles above one field down
    private void deleteRowAndShift(int rowY) {
        deleteRow(rowY);
        for (int y = rowY; y < height; y++) {
            for (int x = 0; x < width; x++) {
                grid[x,y] = grid[x,y+1];
            }
        }
    }
    private void deleteRow(int rowY) {
        for (int x = 0; x < width; x++) {
            grid[x, rowY] = Shape.NULL;
        }
    }
    public void insertShape(PlayablePiece piece) {

        for (int i = 0; i < piece.Cells.Length; i++) {
            int xArr = piece.Cells[i].x + piece.position.x;
            int yArr = piece.Cells[i].y + piece.position.y;
            addTile(xArr ,yArr , piece.data.shape);
        }
    }

    public bool isOver() { return gameOver; }
}
