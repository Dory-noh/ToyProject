using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver = false;
    public int score = 0;
    [SerializeField] Text scoreText;
    

    void Start()
    {
        if(instance==null) instance = this;
        else if(instance!=this) Destroy(gameObject);
    }

    public void updateScore(int point){
        score+=point;
        scoreText.text = $"점수 : {score.ToString()}"; 
    }

}
