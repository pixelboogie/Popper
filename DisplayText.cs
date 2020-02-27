using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayText : MonoBehaviour
{
//     public TextMeshPro BummersText;
    public TextMeshPro ballonsText;
    private int ballonPopCount = 0;
//     private int bummersLeft = 10;

      private int levelIndex;
      public int maxBalloons = 3;

    void Update()
    {
        ballonsText.text = ballonPopCount.ToString();
      //   BummersText.text = bummersLeft.ToString();
        if (Score.bummersLeft <= 0)
        {
                Debug.Log("++++++++++++++++ Go to EndScene");
            // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
      //      SceneManager.LoadScene("EndSceneLose");
       SceneManager.LoadScene("EndScene");
  
        }
    }

    public void BallonPopIncrease()
    {
        ballonPopCount++;

      if(ballonPopCount > maxBalloons){
            // Debug.Log("Got them all");
            Score.myLevels++; // count the level as completed
            levelIndex = SceneManager.GetActiveScene ().buildIndex + 1;
            SceneManager.LoadScene (levelIndex);
      }

    }

    public void LivesDecrease()
    {
        Score.bummersLeft--;
    }

  
}
