using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLight : MonoBehaviour
{
    private Light _myLight;
    private float timer = 0;
    [SerializeField] private float speed = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false; für Felix
        _myLight = GetComponent<Light>();
    }
    
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorPos.x, cursorPos.y, -20.0f);
        timer += 0.001f;
        _myLight.spotAngle = 21 - timer * speed;
        if (_myLight.spotAngle <= 2)
        {
            _myLight.spotAngle = 21;
            timer = 0;
        }
    }
}
