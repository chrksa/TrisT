using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector3Int HandleInputMovement()
    {
        Vector3Int direction = Vector3Int.zero;
        if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector3Int.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector3Int.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3Int.down;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3Int.up;
        }
        return direction;
    }
    
    public bool HandleInputRotation()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.R))
            return true;
        return false;
    }
    
}
