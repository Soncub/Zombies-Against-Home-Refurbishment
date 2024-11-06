using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenScene : MonoBehaviour
{
    public void LoadLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ZAHRLevelBlockout");
    }

    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
    }
}
