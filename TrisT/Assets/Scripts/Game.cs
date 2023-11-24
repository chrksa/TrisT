using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    int[,] board;
    const int x = 10;
    const int y = 20;

    enum color
    {
        Empty,
        Red,            
        Green,
        Blue,
        Yellow,
        Pink,
        Purple,
        Orange,
        Brown,
        White
    }
    /*
        0 = empty
        1 = red 
        2 = blue  
        3 = green
        4 = yellow
        5 = pink
        6 = purple 
        7 = orange
        8 = brown
        9 = white
     */
    void Start()
    { 
        board = new int[x,y];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
