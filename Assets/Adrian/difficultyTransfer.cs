using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class difficultyTransfer : MonoBehaviour
{
    public int Difficulty; // 1 == easy 2 == normal 3 == hard
    GameManager gameManager;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGameScreen()
    {
        SceneManager.LoadScene("GameScreen");
        //gameManager = GameObject.FindAnyObjectByType<GameManager>();
        //gameManager.SetGameDifficulty(Difficulty);
    }

    public void SetDifficulty(int difficulty)
    {
        Difficulty = difficulty;
    }


}
