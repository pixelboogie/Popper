using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayOrQuit : MonoBehaviour
{
      void Start()
      {


      }


      private void OnTriggerEnter(Collider other)
      {

            if (other.CompareTag("DoorReplay"))
            {
                  Score.totalPops = 0; // reset the score to 0 if we replay
                  Score.myLevels = 0; // reset the levels
                  GameVariables.bummers = 0;

                  UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/01");

            }
            if (other.CompareTag("DoorExit"))
            {

           


                  // save any game data here
#if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
#else
                  Application.Quit();
#endif
                  // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                  //   EditorApplication.isPlaying = false;
                  //    Application.Quit();
            }

      }
}
