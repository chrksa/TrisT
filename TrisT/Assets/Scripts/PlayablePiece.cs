
using UnityEngine;

public class PlayablePiece : MonoBehaviour
{
    
    Vector3Int _position;
    GameObject _shape;
    Shape _shapeData;
    void Init(int shapeType)
    {
        _position = new Vector3Int(0, 19, 0);
        _shapeData = gameObject.AddComponent<Shape>();
        _shape= _shapeData.GetShape((Shape.ShapeType)shapeType);
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy PlayablePiece");
        // Todo: PlayablePiece is destroyed, so we need to create PlacedBlock's
        // Todo: PlayablePiece is destroyed, check for row  
        Destroy(_shape);
        
    }
    
    private void CreateShape(int shapeType, Vector3Int position)
    {
        _position = position;
        Instantiate(_shape, _position, Quaternion.identity);
        
    }
}
