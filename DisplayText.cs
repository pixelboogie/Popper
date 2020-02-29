using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayText : MonoBehaviour
{

    public TextMeshPro popsThisLevel;
     public static int ballonPopCount = 0;
    public static int popsLastRound;


      private int levelIndex;
      public int maxBalloons = 3;

      private bool alreadyRan = false; // to stop it from adding multiple levels completed

    void Update()
    {

//     Debug.Log("++++++++++++++++ DisplayText Update called. Score.bummersLeft: " + Score.bummersLeft);

        popsThisLevel.text = ballonPopCount.ToString();

            //  Debug.Log("---------------------------bummersLeft" + Score.bummersLeft);
 
        if (Score.bummersLeft <= 0)
        {
            //     Debug.Log("++++++++++++++++ Go to EndScene");
            // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
      //      SceneManager.LoadScene("EndSceneLose");
       SceneManager.LoadScene("EndScene");
  
        }
    }

    public void BallonPopIncrease()
    {

            //      Debug.Log("++++++++++++++++ BallonPopIncrease called");

        ballonPopCount++;

      if((ballonPopCount >= maxBalloons) && (alreadyRan == false)){

            // Debug.Log("++++++++++++++++ BallonPopIncrease if statement ");

            alreadyRan = true;
            // Debug.Log("Got them all");
            Score.myLevels++; // count the level as completed
            Score.popsLastLevel = ballonPopCount; 
            levelIndex = SceneManager.GetActiveScene ().buildIndex + 1;
            SceneManager.LoadScene (levelIndex);
      }

    }

    public void LivesDecrease()
    {
      //      Debug.Log("++++++++++++++++ LivesDecrease called");
      //   GameVariables.bummers++;
    }

  
}
