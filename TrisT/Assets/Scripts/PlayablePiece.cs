using UnityEngine;
using static UnityEditor.FilePathAttribute;
/*
 Zum kontrollieren des Spielsteins
 */

public class PlayablePiece : MonoBehaviour
{
    public Board board { get; private set; }
    public Vector3Int position{ get; private set; } // Hier vector3 anstatt vector 2, da tilemaps Vector3 benutzen und wir jetzt das Piece auch darstellen wollen
    public ShapeData data { get; private set; }
    
    public Vector3Int[] Cells { get; private set; } // GameBoard 
    public Vector3Int speed = new Vector3Int(0,0,0);

    //----------------------------------------------
    enum ROTATION { right = 0, left = 1 };
    ROTATION rotation = ROTATION.right;
    //----------------------------------------------

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
   
    public void SetSpeedWithInput()
    {
        Vector3Int dir = new Vector3Int(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.W))
        {
            dir.y = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            dir.y = -1;
        }
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D)) return;
        if (Input.GetKeyDown(KeyCode.A))
        {
            dir.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dir.x = 1;
        }
        this.speed = dir;

    }
    public void Rotate90() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Vector3Int[] newCells = new Vector3Int[Cells.Length];

            for (int i = 0; i < Cells.Length; i++)
            {
                Vector3Int cur = Cells[i];

                if (rotation == ROTATION.right)
                {
                    newCells[i] = new Vector3Int(cur.y, -cur.x, cur.z);
                }
                else
                {
                    newCells[i] = new Vector3Int(-cur.y, cur.x, cur.z);
                }
            }
            Cells = newCells;
        }
    }


}
