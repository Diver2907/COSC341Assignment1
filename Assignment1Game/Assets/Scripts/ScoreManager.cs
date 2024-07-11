using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    int highscore = 0;

    private void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        setupScore();
        scoreText.text = "SCORE: "+ score.ToString();
        highScoreText.text = "HIGHSCORE: "+ highscore.ToString();
    }

    // Update is called once per frame
    public void AddPoint(){
        score += 1;
        scoreText.text = "SCORE: "+ score.ToString();
        if(highscore<score){
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void clearScore(){
        score = 0;
        scoreText.text = "SCORE: "+ score.ToString();
    }

    public void setupScore(){
        highscore = PlayerPrefs.GetInt("highscore",0);
    }
}
