using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Board _board;
    
    // Start is called before the first frame update
    void Start()
    {  
        //Todo: init methods
        Board _board = gameObject.AddComponent<Board>();
        _board.Init();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*  Todo: Lifecicle
            1: Check for row
            2: ...
        */ 
        
    }
}
