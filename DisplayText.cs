using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayText : MonoBehaviour
{

      public TextMeshPro popsThisLevelText;
      public static int popsThisLevel;
      public static int ballonPopCount;
      public static int popsLastRound;


      private int levelIndex;
      public int maxBalloons;

      private bool alreadyRan = false; // to stop it from adding multiple levels completed

      public GameObject myAnimatorObject;
      Animator myAnimator;

      private bool alreadyFaded = false; // have we faded in yet
      private float waitTime = 1f; // time to wait before fading in

      private int difference = 0;

      void Start()
      {
            popsThisLevel = 0;
            myAnimator = myAnimatorObject.GetComponent<Animator>();

      }


      void Update()
      {
            popsThisLevelText.text = popsThisLevel.ToString();
            Score.popsRemaining = maxBalloons - popsThisLevel;
            if (Score.bummersLeft <= 0)
            {
                  Score.popsLastLevel = popsThisLevel; ///add this to make it display on game over scene
                  SceneManager.LoadScene("EndSceneLose");
            }


            if (!alreadyFaded)
            {
                  waitTime -= Time.deltaTime;
                  if (waitTime <= 0)
                  {
                        fadeIn();
                  }
            }

      }

      public void BallonPopIncrease()
      {
            if (alreadyRan == false)
            {
                  popsThisLevel++;
                  Score.totalPops++;
                  checkMaxBalloons();
            }
      }


      public void goNextLevel()
      {
            levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(levelIndex);
      }


      private void fadeIn()
      {
            alreadyFaded = true;
            myAnimator.SetTrigger("playIntersceneFadeOut");  // when we start, fade out the sphere
      }


      public void checkMaxBalloons()
      {
            if ((popsThisLevel >= maxBalloons) && (alreadyRan == false))
                   {
                  alreadyRan = true;
                  difference = popsThisLevel - maxBalloons;
                  Score.totalPops -= difference;
                  popsThisLevel = maxBalloons;
                  Score.popsLastLevel = maxBalloons;
                  Score.myLevels++; 
                  playOutroAnim();

            }
      }


      public void playOutroAnim()
      {
            myAnimator.SetTrigger("playIntersceneFadeIn");
      }

}
