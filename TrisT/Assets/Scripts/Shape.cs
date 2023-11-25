using UnityEngine;
using UnityEngine.Tilemaps;

public enum Shape
{ 
    L,
    I,
    O,
    T,
    J,
    S,
    Z,
    Q,       // single Cube
    P        // PLUS
}

[System.Serializable]
public struct ShapeData 
{
    public Shape shape;
    public Tile tile;
    public Vector2Int[] cells { get; private set; } // {  get; private set; } damit es nicht im Editor mit angezeigt wird 
                                                    // ohne sind custom shades im Editor möglich

    public void Init() 
    {
        this.cells = Dictionary.Cells[this.shape];    
    }
}