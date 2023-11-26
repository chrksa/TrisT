using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private static int a;
    private static Stack<int> sceneHistory = new Stack<int>();

    public void PlayGame()
    {
        sceneHistory.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        sceneHistory.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(2);
    }

    public void Achievements()
    {
        sceneHistory.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(3);
    }

    public void PreviousScene()
    {
        SceneManager.LoadSceneAsync(sceneHistory.Pop());
    }
}
