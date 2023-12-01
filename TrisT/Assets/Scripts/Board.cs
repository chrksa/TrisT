
using UnityEngine;
[System.Serializable]
public class Board : MonoBehaviour
{
    // Singleton
    public static Board board;
    
    // Shapes PlayablePiece
    public GameObject[] Shapes {get; private set; }

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
        
        
    }


}
