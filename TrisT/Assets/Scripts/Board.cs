using UnityEngine;
using UnityEngine.Tilemaps;

/*
 Kontrolliert alles auf dem Board, außer den Spielstein(nur SpawnShape())
 */

public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; } // reference zur Tilemap um malen zu können
    public ShapeData[] shapes;
    public PlayablePiece activePiece;
    public Vector3Int spawnPos { get; private set; }
    public Vector2Int boardSize = new Vector2Int(10,20);

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

    private void Start() => SpawnShape();

    private void GameOver()
    {
        tilemap.ClearAllTiles();
    }
    private void SpawnShape() 
    {
        int rand = Random.Range(0, this.shapes.Length);
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

    private void IsLineFull()   // überprüfe jede Spalte auf 10 pieces
    {

    }

    private void Update()
    {

        Clear(this.activePiece);
        activePiece.SetSpeedWithInput();
        activePiece.GetNewPosition();
        Set(this.activePiece);
        

        


    }
}
