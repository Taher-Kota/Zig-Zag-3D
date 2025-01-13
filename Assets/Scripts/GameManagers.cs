using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;
    public Color color;

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level2") {
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().backgroundColor = color;
        }
        if(SceneManager.GetActiveScene().name == "Level3")
        {
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().backgroundColor = color;
        }
    }
    void Update()
    {
        Gameover();
        if (SceneManager.GetActiveScene().name == "ZigZag" || SceneManager.GetActiveScene().name == "Level2")
        {
            LevelComplet();
        }
    }
    
    public void GameStart()
    {
        UIManagers.instance.GameStart();
    }

    void Gameover()
    {
        if (PlayerControl.instance.gameObject.transform.position.y < -1.9)
        {
            
            ScoreManagers.instance.StopScore();
            ScoreManagers.instance.SetScores();
            UIManagers.instance.GameOver();
            TileInstantiator.instance.Gameover = true;
            PlayerControl.instance.gameObject.SetActive(false);
        }
    }

    public void LevelComplet()
    {
        if (ScoreManagers.instance.Score == 15)
        {
            Time.timeScale = 0;
            UIManagers.instance.LevelComplete();
        }
    }
    public void NextLevelButton()
    {
        ScoreManagers.instance.Score = 0;
        Time.timeScale = 1;
        //UIManagers.instance.NextlevelPanel.SetActive(false);
        if (SceneManager.GetActiveScene().name == "ZigZag")
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            SceneManager.LoadScene("Level3");
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}
