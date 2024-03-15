using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameScreen()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void LoadDifficultyMenu()
    {
        SceneManager.LoadScene("DifficultyMenu");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
