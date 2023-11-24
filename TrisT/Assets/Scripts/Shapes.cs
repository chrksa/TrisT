

using UnityEngine.Tilemaps;

public enum Shape
{ 
    Empty,
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
public struct Shapes 
{
    public Shape Shape;
    public Tile tile;
    

}