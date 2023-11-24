using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArray : MonoBehaviour
{
    static int[,] board;
    // Start is called before the first frame update
    void Start()
    {
        const int x = 10;
        const int y = 20;
        int[,] board = new int[x,y];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
