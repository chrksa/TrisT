using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLight : MonoBehaviour
{
    //test
    private Light _myLight;
    private float timer = 0;
    [SerializeField] private float speed = 6;
    private Color color1;
    private Color color2;
    
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false; für Felix
        _myLight = GetComponent<Light>();
        
        //_myLight.color = new Color(249, 217,123, 255);
        /*color1 = new Color(249.0f / 255.0f, 211.0f / 255.0f, 123.0f / 255.0f, 0.7f);
        color2 = new Color(249.0f / 255.0f, 211.0f / 255.0f, 123.0f / 255.0f, 1);*/
    }
    
    void Update()
    {
        /*double Dtime = (double) Time.time;
        double test = (Math.Sin(Dtime * 3) + 1) /2;
        float amp = 10;*/
        //_myLight.color = Color.Lerp(color1, color2, (float)test);
        
        
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
