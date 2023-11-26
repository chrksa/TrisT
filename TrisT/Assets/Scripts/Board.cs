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
    public int xMax = 10;
    public int xMin = -10;
    public int yMax = 10;
    public int yMin = -10;
    public Tilemap tilemap { get; private set; } // reference zur Tilemap um malen zu können
    public ShapeData[] shapes;
    public int[,] tilegrid;
    public PlayablePiece activePiece;
    public PlacedBlock placedPiece;
    public Vector3Int spawnPos { get; private set; }
    public const int width = 20;
    public const int height = 20;

    //PlacedPiece arr;

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
        this.placedPiece = GetComponentInChildren<PlacedBlock>();
        tilegrid = new int[width+2, height+2];
        for (int i = 0; i < width + 2; i++) 
        {
            for (int j = 0; j < height + 1; j++) 
            {
                if (i == 0 || i == (width) || j == 0 || j == (height))
                {
                    tilegrid[i, j] = 10;
                    Debug.Log(i + " " + j +" "+ tilegrid[i,j]);

                }
                else 
                {
                    tilegrid[i, j] = 0;
                }
            }
        }
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
        Debug.Log("tilegrid" + tilegrid[0, 0]);
        SetTileGridMaP();
        //arr = new PlacedPiece(this);
    }
    private void SetTileGridMaP() 
    {
        Vector3Int cur= new Vector3Int(0,0,0);
        for (int i = 0; i < 20; i++)
            for (int j = 0; j < 20; j++) 
            {
                cur.x = i-10;
                cur.y= j-10;
                tilemap.SetTile(cur, shapes[0].tile);
            }
        
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
        spawnPos = new Vector3Int(0, 0, 0);
        this.activePiece.Init(this.spawnPos, shape, this);
        Set(this.activePiece);
    }

    private void Set(PlayablePiece piece)
    {
        this.activePiece = piece;
        for (int i = 0; i < piece.Cells.Length; i++)
        {
            Vector3Int tilePosition = piece.Cells[i] + piece.position; // global position
            this.tilemap.SetTile(tilePosition, piece.data.tile); // male tile 
        }
    }

    public void Clear(PlayablePiece activePiece)
    {
        for (int i = 0; i < activePiece.Cells.Length; i++)
        {
            Vector3Int tileposition = activePiece.Cells[i] + activePiece.position;
            tilemap.SetTile(tileposition, null);
        }
    }
    public void PlayerMovement(bool underneatchCheck, bool leftsidecheck, bool rightsidecheck)
    {
        activePiece.dir = new Vector3Int(0, 0, 0);
        if (!underneatchCheck)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                activePiece.dir.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D)) return;

        if (!leftsidecheck)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                activePiece.dir.x = -1;
            }
        }
        if (!rightsidecheck)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                activePiece.dir.x = 1;
            }
        }
    }
    private void Update()
    {

        Clear(this.activePiece);
        PlayerMovement(activePiece.UnderneathCheck(), activePiece.LeftSideCheck(), activePiece.RightSideCheck());
        activePiece.SetNewPosition();
        Set(activePiece);
        /*activePiece.Rotate90();
        if (!activePiece.GetNewPosition()) { 
            //arr.insertShape(this.activePiece);
            //SpawnShape();
        }
        Set(this.activePiece);
        */
        //arr.drawPlacedTiles();


    }

    // ist nicht jeden Frame
    private void DrawUpdate()
    {
        //clear map
        Clear(this.activePiece);

        //check movable 
        if (activePiece.UnderneathCheck() == false) 
        {
            this.activePiece.addFallSpeed();
            activePiece.SetNewPosition();
            Set(activePiece);

        }

        //add fallspeed

    }
    private void ScaleDrawUpdateSpeed()
    {
        DateTime end = DateTime.Now;
        if (end.Second - start.Second > 30)
        {
            start = end;
            scale *= 2;
        }
    }
    //return false if its in the border
}
