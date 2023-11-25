using UnityEngine;
/*
 Zum kontrollieren des Spielsteins
 */

public class PlayablePiece : MonoBehaviour
{
    public Board board { get; private set; }
    public Vector3Int position{ get; private set; } // Hier vector3 anstatt vector 2, da tilemaps Vector3 benutzen und wir jetzt das Piece auch darstellen wollen
    public ShapeData data { get; private set; }
    
    public Vector3Int[] Cells { get; private set; } // GameBoard 
    public Vector3Int speed = new Vector3Int(0,-1,0);

    public void Init(Vector3Int position, ShapeData playstonedata, Board board) // board um zugriff auf spiel zu haben
    {
        
        this.position = position;
        this.data = playstonedata;
        this.board = board;
        


        if (this.Cells == null) 
        {
            this.Cells= new Vector3Int[data.cells.Length]; // Anzahl an Blöcken des Spielsteine meist 4, custom pieces haben 1 oder 5 (dot oder plus)
        }

        for (int i = 0; i < data.cells.Length; i++) 
        {
            this.Cells[i]= (Vector3Int)data.cells[i]; // piece an stelle setzen ?
        }

    }

    public Vector3Int GetNewPosition()
    {
        return position= this.position + speed;
    }
    private void Update()
    {
        //clear auf dem board
        board.Clear(this);

        if ()

    }

    
}
