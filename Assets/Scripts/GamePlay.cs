using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {
    private IEnumerator corou;
    public float randX;
    [SerializeField]
    private GameObject GameOverPanel;
    public int score;
    public static GamePlay instance;
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private GameObject StartPanel;
    [SerializeField]
    private Text ScoreEndGame;
    [SerializeField]
    private Text BestScoreEndGame;
    public bool end;
    private void Awake()
    {  
        Time.timeScale = 0;
        _makeInstance();;
    }

    void _makeInstance()
    {
        if (instance == null) instance = this;
    }

    public void _StartGame()
    {
        Application.LoadLevel("GamePlay");
    }

    public void _playGame()
    {
        Time.timeScale = 1;
        StartPanel.SetActive(false);
    }

    private void Update()
    {
        _setScore(score);
        checkEndGame();
    }
    void _setScore(int score)
    {
        ScoreText.text = "" + score;
    }

    void checkEndGame()
    {
        if (end)
        {
            Debug.Log("end Game " + GameScoreMananger.instance.getHighScore());
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
            ScoreEndGame.text = "" + GamePlay.instance.score;
            if(GamePlay.instance.score > GameScoreMananger.instance.getHighScore())
            {
                
                GameScoreMananger.instance.setHighScore(score);
            }
            
            BestScoreEndGame.text = "" + GameScoreMananger.instance.getHighScore();
        }
    }
}
