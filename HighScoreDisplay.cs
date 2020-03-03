using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{

        public TextMeshPro highScoreText;
        public int highScore;

    // Start is called before the first frame update
    void Start()
    {
      //   instance = this;
        if(PlayerPrefs.HasKey("HighScore")){
            highScore = PlayerPrefs.GetInt("HighScore");
              highScoreText.text = highScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Score.scoreCalculation > highScore){
              highScore = Score.scoreCalculation;
              highScoreText.text = highScore.ToString();
              PlayerPrefs.SetInt("HighScore", highScore);
        }
    }






}
