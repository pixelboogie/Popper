using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayText : MonoBehaviour
{
    public TextMeshPro livesText;
    public TextMeshPro ballonsText;
    private int ballonPopCount = 0;
    private int livesLeft = 10;

      private int levelIndex;
      public int maxBalloons = 3;





    // Update is called once per frame
    void Update()
    {
        ballonsText.text = "Pops this rounds: " + ballonPopCount.ToString();
        livesText.text = "Lives: " + livesLeft.ToString();
        // restart if dead.
        if (livesLeft == 0)
        {
            // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
        }
    }

    public void BallonPopIncrease()
    {
        ballonPopCount++;

      if(ballonPopCount > maxBalloons){
            Debug.Log("Got them all");
            
            levelIndex = SceneManager.GetActiveScene ().buildIndex + 1;
            SceneManager.LoadScene (levelIndex);
      }

    }

    public void LivesDecrease()
    {
        livesLeft--;
    }

  
}
