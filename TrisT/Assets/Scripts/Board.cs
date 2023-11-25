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

    private void Awake() 
    {
        this.tilemap = GetComponentInChildren<Tilemap>();  // tilemap ist child von GameObject, dass mit Board verknüpft ist
        this.activePiece = GetComponentInChildren<PlayablePiece>();

        for (int i = 0; i < this.shapes.Length; i++) 
        {
            this.shapes[i].Init();
        }
    }

    private void Start() => SpawnShape();

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
        for (int i = 0;i < piece.Arr.Length; i++) 
        {
            Vector3Int tilePosition = piece.Arr[i]+piece.position; // global position
            this.tilemap.SetTile(tilePosition, piece.data.tile); // male tile 
        }
    }
}
