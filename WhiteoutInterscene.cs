using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class WhiteoutInterscene : MonoBehaviour
{
      private int levelIndex;

      public void goNextLevel()
      {
            levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(levelIndex);
      }

}
