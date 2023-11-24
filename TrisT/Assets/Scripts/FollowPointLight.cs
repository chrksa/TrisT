using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointLight : MonoBehaviour
{
    
    
    private float mouseCursorSpeed;
    private Light light;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //light.spotAngle = (int) (22 / (Vector2.Distance(oldpos, transform.position) + 1) * spotAngleFactor);
        //Debug.Log("" + Vector2.Distance(oldpos, transform.position));
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorPos.x, cursorPos.y, -5.0f);

        
    }
}