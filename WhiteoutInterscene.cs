using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class WhiteoutInterscene : MonoBehaviour
{

         private int levelIndex;

         
      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }


      public void goNextLevel()
      {
            // Debug.Log("++++++++++++++++ goNextLevel called");
            levelIndex = SceneManager.GetActiveScene().buildIndex + 1;

            SceneManager.LoadScene(levelIndex);
      }

}
