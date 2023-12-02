using UnityEngine;

public class Board : MonoBehaviour
{
    // Singleton
    public static Board _board;
    
    
    
    //Inputhandler
    public PlayerInputHandler playerInputHandler;
    
    //PlayablePiece
    public PlayablePiece playablePiece;
    
    //PlayablePiece
    Vector3Int _defaultSpawnPosition = new Vector3Int(10, 18, 0);
    
    // Board dimensions
    private float _xMax;
    private float _xMin;
    private float _yMax;
    private float _yMin;

    private void Awake()
    {
        Init(20, 0, 20, 0);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Init(float xMax, float xMin, float yMax, float yMin)
    {
        Debug.Log("Board Init");
        //Board dimensions
        _xMax =  xMax;
        _xMin =   xMin;
        _yMax =  yMax;
        _yMin =   yMin;
        
        
        //PlayablePiece
        playablePiece = gameObject.AddComponent<PlayablePiece>();
        Debug.Log("Shapes: " + playablePiece);
        playablePiece.Init();
        SpawnRandomPlayablePiece();
        
        
        //Inputhandler
        playerInputHandler = gameObject.AddComponent<PlayerInputHandler>();
        
        Debug.Log("Board Init done");
    }
    
    
    
    // used in GameManager.cs
    public void Update()
    {
        /*Vector3Int direction = playerInputHandler.HandleInputMovement();
        if (direction != Vector3Int.zero)
        {
            playablePiece.Move(direction);
            
        }
        
        if (playerInputHandler.HandleInputRotation())
        {
            playablePiece.Rotate();
        }*/
        
    }
    public void FixedUpdate()
    {
        //Todo: auto move down
    }
    public void SpawnRandomPlayablePiece()
    {
        int rand= Random.Range(0, 6);
        playablePiece.CreateShape(rand, _defaultSpawnPosition);
    }
    
}
