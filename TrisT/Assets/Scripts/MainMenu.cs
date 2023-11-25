using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        Cursor.visible = false;
    }

    public void Options()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
