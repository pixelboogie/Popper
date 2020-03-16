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
      public int maxBalloons = 3;

      private bool alreadyRan = false; // to stop it from adding multiple levels completed

  public  GameObject myAnimatorObject;
  Animator myAnimator;

  private bool alreadyFaded = false; // have we faded in yet
        private float waitTime = 1f; // time to wait before fading in

    void Start()
    {
          popsThisLevel=0;
            myAnimator = myAnimatorObject.GetComponent<Animator>();
            
    }


    void Update()
    {

//     Debug.Log("++++++++++++++++ DisplayText Update called. Score.bummersLeft: " + Score.bummersLeft);

        popsThisLevelText.text = popsThisLevel.ToString();

            //  Debug.Log("---------------------------bummersLeft" + Score.bummersLeft);
 
        if (Score.bummersLeft <= 0)
        {
            //     Debug.Log("++++++++++++++++ Go to EndScene");
            // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
      //      SceneManager.LoadScene("EndSceneLose");

     Score.popsLastLevel = popsThisLevel; ///add this to make it display on game over scene

       SceneManager.LoadScene("EndSceneLose");
  
        }


        if(!alreadyFaded){


              waitTime -= Time.deltaTime;

                  if (waitTime <= 0)
                  {
                      
                      fadeIn();
                     

                  }
                  }

    }

    public void BallonPopIncrease()
    {

            //      Debug.Log("++++++++++++++++ BallonPopIncrease called");

        popsThisLevel++;

      if((popsThisLevel >= maxBalloons) && (alreadyRan == false)){

            Debug.Log("++++++++++++++++ BallonPopIncrease if statement ");

            alreadyRan = true;
            // Debug.Log("Got them all");
            Score.myLevels++; // count the level as completed
            Score.popsLastLevel = popsThisLevel; 

      // myAnimator.playIntersceneOver();
      // myAnimator.Play("")
       myAnimator.SetTrigger("playIntersceneFadeIn");
      }

    }

    public void LivesDecrease()
    {
      //      Debug.Log("++++++++++++++++ LivesDecrease called");
      //   GameVariables.bummers++;
    }



    public void goNextLevel()
    {
                   Debug.Log("++++++++++++++++ goNextLevel called");
      levelIndex = SceneManager.GetActiveScene ().buildIndex + 1;

            SceneManager.LoadScene (levelIndex);
    }


    private void fadeIn(){
   alreadyFaded = true;
    myAnimator.SetTrigger("playIntersceneFadeOut");  // when we start, fade out the sphere
    }



  
}
