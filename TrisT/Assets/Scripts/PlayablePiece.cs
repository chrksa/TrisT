using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
/*
 Zum kontrollieren des Spielsteins
 */

public class PlayablePiece : MonoBehaviour
{
    public Board board { get; private set; }
    public Vector3Int position { get; private set; }// Hier vector3 anstatt vector 2, da tilemaps Vector3 benutzen und wir jetzt das Piece auch darstellen wollen

    public ShapeData data { get; private set; }


    public Vector3Int[] Cells { get; private set; } // GameBoard 
    public Vector3Int FallSpeed = new Vector3Int(0, -1, 0);
    public Vector3Int HorizontalMovementSpeed = new Vector3Int(1, 0, 0);
    public Vector3Int dir = new Vector3Int(0, 0, 0);
    public Vector3Int lastpos = new Vector3Int(0, 0, 1);

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
            this.Cells = new Vector3Int[data.cells.Length]; // Anzahl an Blöcken des Spielsteine meist 4, custom pieces haben 1 oder 5 (dot oder plus)
        }

        for (int i = 0; i < data.cells.Length; i++)
        {
            this.Cells[i] = (Vector3Int)data.cells[i]; // piece an stelle setzen ?
        }

    }

    public void SetNewPosition()
    {
        lastpos = position;

        //Debug.Log("Lastpos = "+lastpos.x + " " + lastpos.y + " " + lastpos.z);
        //Debug.Log("Position = "+position.x + " " + position.y + " " + position.z);
        if (Vector3.Magnitude(lastpos - position) > 0)
        {
            //Debug.Log("Passt");
        }
        position = position + dir;
        dir = new Vector3Int(0, 0, 0);

    }
    /*public bool CheckMove()
    {
        
        if (lastpos.x == position.x && lastpos.y == position.y)
        {
            Debug.Log("wieso");
            return false;
        }
        Debug.Log("Checkmove True");
        return true;
    }*/
    public void addFallSpeed()
    {
        position = position + FallSpeed;
    }

    public bool LeftSideCheck()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            int xPos = Cells[i].x + position.x - 1;
            int yPos = Cells[i].y + position.y;
            if ((board.xMin) - 1 > xPos) return true;
            if (board.tilegrid[xPos + 11, yPos + 11] != 0) return true;
        }
        Debug.Log("leftSideCheck=False");
        return false;
    }
    public bool RightSideCheck()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            int xPos = Cells[i].x + position.x;
            int yPos = Cells[i].y + position.y;
            if ((board.xMax) + 9 < xPos) return true; // 11
            if (board.tilegrid[xPos + 11, yPos + 11] != 0) return true;
        }
        return false;
    }
    public bool UnderneathCheck()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            int xPos = Cells[i].x + position.x;
            int yPos = Cells[i].y + position.y + 1;
            //if (-(board.yMin / 2) + 1 > this.position.y) return true; 
            if (board.tilegrid[xPos + 11, yPos + 9] != 0) return true;
        }
        return false;
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
