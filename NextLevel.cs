using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class NextLevel : MonoBehaviour
{

      public float transitionTime = 2f;
      private int levelIndex;


      void Update()
      {

            transitionTime -= Time.deltaTime;
            if (transitionTime < 0)
            {
                  loadNextLevel();
            }
      }


      public void loadNextLevel()
      {
            levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(levelIndex);
      }





}
