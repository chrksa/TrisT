using UnityEngine;



[System.Serializable]
public class Shape : MonoBehaviour
{   
    public enum ShapeType
    {
        I,
        J,
        L,
        O,
        S,
        T,
        Z
    }
    
    // full with all shapes
    public GameObject[] ShapeData {get; private set; } 
    
    public GameObject GetShape(ShapeType shapeType)
    {
        return ShapeData[(int)shapeType];
    }
}