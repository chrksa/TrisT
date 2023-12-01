using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager gameManager;
    
    Board _board;
    
    // Start is called before the first frame update
    void Start()
    {  
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);  // Dont destroy this object when loading a new scene
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
        
        //Todo: init Board
        Board _board = gameObject.AddComponent<Board>();
        _board.Init();
        /*
         * Board boarders
         * PlayablePiece init
         */
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
