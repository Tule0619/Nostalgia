// Joshua Chisholm
// 10/4/24
// Methods to change the current scene based on context.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    /// <summary>
    /// Changes the current scene to the game screen
    /// </summary>
    public void ChangeToGame() 
    {
        SceneManager.LoadScene("Game");
    }
    /// <summary>
    /// Changes the current scene to the game screen
    /// </summary>
    public void ChangeToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    /// <summary>
    /// Changes the current scene to the game screen
    /// </summary>
    public void ChangeToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
