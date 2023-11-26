using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        Cursor.visible = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
