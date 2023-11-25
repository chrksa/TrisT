using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointLight : MonoBehaviour
{
    
    public Vector3 mouseDelta = Vector3.zero;
    private Vector3 lastMousePosition = Vector3.zero;
    
    private float _mouseCursorSpeed;
    private Light _myLight;
    private float timer = 0;
    [SerializeField] private float speed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        _myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += 0.001f;
        _myLight.range = 6.5f - timer * speed;

        if (_myLight.range < 1) 
        {
            _myLight.range = 6.5f;
            timer = 0;
        }
        
            
        
       
        
        //light.spotAngle = (int) (22 / (Vector2.Distance(oldpos, transform.position) + 1) * spotAngleFactor);
        //Debug.Log("" + Vector2.Distance(oldpos, transform.position));
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorPos.x, cursorPos.y, -5.0f);

        
    }
}