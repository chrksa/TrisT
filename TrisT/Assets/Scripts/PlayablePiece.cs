using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayablePiece : MonoBehaviour
{

    
    Vector3Int _position;
    GameObject _shape;
    public GameObject[] Shapes; // 0: I, 1: J, 2: L, 3: O, 4: S, 5: T, 6: Z

    public void Init()
    {
        SetShapes();
    }

    /// <summary>
    ///   Destroy PlayablePiece - Log, create PlacedBlock's and check for row
    /// </summary>
    public void ManualDestroy()
    {
        Debug.Log("Destroy PlayablePiece");
        // Todo: PlayablePiece is destroyed, so we need to create PlacedBlock's
        // Todo: PlayablePiece is destroyed, check for row  
        Destroy(_shape);
        
    }
    /// <summary>
    ///  Create a PlayablePiece at spawnposition (Instantiate)
    /// </summary>
    /// <param name="shapeType"></param>
    /// <param name="spawnposition"></param>
    public void CreateShape(int shapeType, Vector3Int spawnposition)
    {
        print(Shapes[shapeType]);
        _position = spawnposition;
        _shape= Instantiate(Shapes[shapeType], _position, Quaternion.identity);
        
    }
    
    public void SetShapes()
    {
        Shapes = new GameObject[7];
        Shapes[0] = Resources.Load<GameObject>("Prefabs/I");
        Shapes[1] = Resources.Load<GameObject>("Prefabs/J");
        Shapes[2] = Resources.Load<GameObject>("Prefabs/L");
        Shapes[3] = Resources.Load<GameObject>("Prefabs/O");
        Shapes[4] = Resources.Load<GameObject>("Prefabs/S");
        Shapes[5] = Resources.Load<GameObject>("Prefabs/T");
        Shapes[6] = Resources.Load<GameObject>("Prefabs/Z");
    }
    
    /// <summary>
    ///  Move PlayablePiece in direction (new position)
    /// </summary>
    /// <param name="direction"></param>
    public void Move(Vector3Int direction)
    {
        _position += direction;
        _shape.transform.position = _position;
    }

    
    /// <summary>
    /// Rotate PlayablePiece 90 degrees
    /// </summary>
    public void Rotate()
    {
        _shape.transform.Rotate(0,0,90);
    }
    
    
    //Todo: Smooth movement
   
}
