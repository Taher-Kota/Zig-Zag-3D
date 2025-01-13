using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagers : MonoBehaviour
{
    [HideInInspector]
    public int Score;
    public static ScoreManagers instance;

    private void Awake()
    {
       instance = this;
    }
    void Start()
    {
        Score = 0;
        PlayerPrefs.SetInt("score", Score);
    }

    void Update()
    {

    }

    public void StopScore(){
        PlayerPrefs.SetInt("score", Score);
       TileInstantiator.instance.CancelInvoke("Spawning");
    }

    internal void SetScores()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            if(Score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", Score);
            }
        }
        else
        {
                PlayerPrefs.SetInt("highScore", Score);          
        }
    }
}
