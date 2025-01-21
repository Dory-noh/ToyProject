using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver = false;
    public int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject GameOverImg;
    [SerializeField] GameObject NextBallPanel;
    [SerializeField] Text FinalScoreText;

    void Awake()
    {
        if(instance==null) instance = this;
        else if(instance!=this) Destroy(gameObject);
    }
    private void Start()
    {
        GameOverImg.SetActive(false);
        NextBallPanel.SetActive(true);
    }
    private void Update()
    {
        if (isGameOver == true)
        {
            GameOverImg.SetActive(true);
            NextBallPanel.SetActive(false);
            FinalScoreText.text = $"Score : {score.ToString("0000")}";
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void updateScore(int point){
        score+=point;
        scoreText.text = $"Score : {score.ToString()}"; 
    }

}
