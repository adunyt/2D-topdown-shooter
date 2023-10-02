using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    public Scene currentScene { get; private set; }

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
