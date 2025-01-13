using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagers : MonoBehaviour
{
    public GameObject GameoverPanel, ZigZagPanel,NextlevelPanel;
    public TextMeshProUGUI Taptostart;
    public TextMeshProUGUI Highestscore, CurrentScore, GameOverHighscore,LiveScore;
    public static UIManagers instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        Highestscore.text = PlayerPrefs.GetInt("highScore").ToString();
    }
    public void GameOver()
    {
        CurrentScore.text = PlayerPrefs.GetInt("score").ToString();
        GameOverHighscore.text = PlayerPrefs.GetInt("highScore").ToString();
        GameoverPanel.SetActive(true);
    }
    public void LevelComplete()
    {
        NextlevelPanel.SetActive(true);
    }
    public void GameStart()
    {
        Taptostart.gameObject.SetActive(false);
        ZigZagPanel.GetComponent<Animator>().Play("PanelUp");
    }
}
