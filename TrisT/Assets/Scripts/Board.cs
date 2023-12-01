
using UnityEngine;

[System.Serializable]
public class Board : MonoBehaviour
{
    // Singleton
    public static Board board;
    
    // Shapes PlayablePiece
    public GameObject[] Shapes {get; private set; }
    
    //Inputhandler
    public PlayerInputHandler playerInputHandler;
    public PlayablePiece playablePiece;
    //PlayablePiece
    Vector3Int _defaultSpawnPosition = new Vector3Int(0, 19, 0);
    
    // Board dimensions
    private float _xMax;
    private float _xMin;
    private float _yMax;
    private float _yMin;

    private void Awake()
    {
        if (board == null)
        {
            DontDestroyOnLoad(gameObject);  // Dont destroy this object when loading a new scene
            board = this;
        }
        else if (board != this)
        {
            Destroy(gameObject);
        }
        
    }
    
    public void Init()
    {
        //Board dimensions
        _xMax =  20f;
        _xMin =   0f;
        _yMax =  20f;
        _yMin =   0f;
        
        // Shapes PlayablePiece
        playablePiece = gameObject.AddComponent<PlayablePiece>();
        int rand= Random.Range(0, 7);
        playablePiece.Init(rand, _defaultSpawnPosition);
        playerInputHandler = gameObject.AddComponent<PlayerInputHandler>();
    }
    
    
    // used in GameManager.cs
    public void Update()
    {
        Vector3Int direction = playerInputHandler.HandleInputMovement();
        if (direction != Vector3Int.zero)
        {
            playablePiece.Move(direction);
            
        }
        
        if (playerInputHandler.HandleInputRotation())
        {
            playablePiece.Rotate();
        }
    }
    
}
