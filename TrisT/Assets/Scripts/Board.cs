using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

/*
 Kontrolliert alles auf dem Board, außer den Spielstein(nur SpawnShape())
 */

public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; } // reference zur Tilemap um malen zu können
    public ShapeData[] shapes;
    public PlayablePiece activePiece;
    public Vector3Int spawnPos { get; private set; }
    public const int width = 20;
    public const int height = 20;

    PlacedPiece arr;

    //-------------------------------------------
    public DateTime start;
    public float scale;
    //-------------------------------------------

    private void Awake() 
    {
        //Framerate 60
        //QualitySettings.vSyncCount = 0; // Vsync disabled
        //Application.targetFrameRate = 60;
        

        this.tilemap = GetComponentInChildren<Tilemap>();  // tilemap ist child von GameObject, dass mit Board verknüpft ist
        this.activePiece = GetComponentInChildren<PlayablePiece>();
       

        for (int i = 0; i < this.shapes.Length; i++) 
        {
            this.shapes[i].Init();
        }
        
    }

    private void Start()
    {
        SpawnShape();
        InvokeRepeating("DrawUpdate", 0f, 1f / 1f);
        this.start = DateTime.Now;
        this.scale = 1f;
        arr = new PlacedPiece(this);
    }

    private void GameOver()
    {
        tilemap.ClearAllTiles();
    }
    private void SpawnShape() 
    {
        int rand = UnityEngine.Random.Range(1, this.shapes.Length);
        ShapeData shape = this.shapes[rand];

        // random spawnfunktion
        spawnPos= new Vector3Int(0, 0, 0);
        this.activePiece.Init(this.spawnPos, shape, this);
        Set(this.activePiece);
    }

    private void Set(PlayablePiece piece)
    {
        this.activePiece = piece;
        for (int i = 0;i < piece.Cells.Length; i++) 
        {
            Vector3Int tilePosition = piece.Cells[i]+piece.position; // global position
            this.tilemap.SetTile(tilePosition, piece.data.tile); // male tile 
        }
    }

    public void Clear(PlayablePiece activePiece) 
    {
        for (int i = 0; i < activePiece.Cells.Length; i++) 
        {
            Vector3Int tileposition= activePiece.Cells[i] + activePiece.position;
            tilemap.SetTile(tileposition, null);
        }
    }

    private void Update()
    {

        Clear(this.activePiece);
        activePiece.Rotate90();
        if (!activePiece.GetNewPosition()) { 
            //arr.insertShape(this.activePiece);
            //SpawnShape();
        }
        Set(this.activePiece);

        //arr.drawPlacedTiles();


    }
    
    private void DrawUpdate() 
    {
        Clear(this.activePiece);

        if (!activePiece.addFallSpeed()) {
            arr.insertShape(this.activePiece);
            Debug.Log("Piece inserted");
            Debug.Log(arr.ToString());
            SpawnShape();
        }
        Set(this.activePiece);


    }
    private void ScaleDrawUpdateSpeed() 
    {
        DateTime end= DateTime.Now;
        if (end.Second - start.Second > 30) 
        {
            start = end;
            scale *= 2;
        }
    }
    //return false if its in the border
    public bool OutOfUBorder(int x, int y) {
        int MinX = -Board.width / 2;
        int MaxX = (Board.width / 2) -1;
        int MinY = -(Board.height / 2) +1;

        if (x < MinX || x > MaxX || y < MinY) return true;

        return false;
    }
    public bool OutOfVerticalBorder(int x, int y) {
        int MinX = -(Board.width / 2);
        int MaxX = (Board.width / 2) - 1;

        if (x < MinX || x > MaxX) return true;

        return false;
    }
    public bool underneathCheck(int x, int y) {
        int MinY = -(Board.height / 2) +1;

        if (y < MinY) return true;

        return false;
    }


}
