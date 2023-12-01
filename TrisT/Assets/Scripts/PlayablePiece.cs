
using UnityEngine;

public class PlayablePiece : MonoBehaviour
{
    
    Vector3Int _position;
    GameObject _shape;
    Shape _shapeData;

    
    
    public void Init(int shapeType, Vector3Int position)
    {
        _position = position;
        _shapeData = gameObject.AddComponent<Shape>();
        _shape= _shapeData.GetShape((Shape.ShapeType)shapeType);
    }

    public void OnDestroy()
    {
        Debug.Log("Destroy PlayablePiece");
        // Todo: PlayablePiece is destroyed, so we need to create PlacedBlock's
        // Todo: PlayablePiece is destroyed, check for row  
        Destroy(_shape);
        
    }
    
    public void CreateShape(int shapeType, Vector3Int spawnposition)
    {
        _position = spawnposition;
        Instantiate(_shape, _position, Quaternion.identity);
        
    }
    
    public void Move(Vector3Int direction)
    {
        _position += direction;
        _shape.transform.position = _position;
    }

    public void Rotate()
    {
        _shape.transform.Rotate(0,0,90);
    }
    
    
    //Todo: Smooth movement
   
}
