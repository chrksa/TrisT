using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; } // reference zur Tilemap um malen zu können
    public ShapeData[] shapes;

    private void Setter() 
    {
        this.tilemap = GetComponentInChildren<Tilemap>();  // tilemap ist child von GameObject, dass mit Board verknüpft ist

        for (int i = 0; i < this.shapes.Length; i++) 
        {
            this.shapes[i].Init();
        }
    }

    private void Start()
    {
        SpawnShape();
    }

    private void SpawnShape() 
    {
        int rand = Random.Range(0, shapes.Length);
        ShapeData shape = this.shapes[rand];
    }

    private void Set()
    {
        
    }
}
