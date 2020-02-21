using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayOrQuit : MonoBehaviour
{


    void Start () {

      //      Debug.Log("*********************************************** started "); 


    }


 private void OnTriggerEnter(Collider other)
    {

//      Debug.Log("*********************************************** Colllision "); 
      //   UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Scene1");


        // This if statement tests what tag the other collider has.
        //If it is zombie then load scene 0. Scene 0 is the first scene in the build order. The second one will be scene 1 and so on.
        //If the tag does not match, nothing will happen.
        if (other.CompareTag("DoorReplay"))
        {
            Debug.Log("*********************************************** I REPLAYED "); 
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Scene1");

                  // GameObject LL = GameObject.Find ("LevelLoader");
                  // LevelLoader LLScript = LL.GetComponent<LevelLoader> ();
                  // LLScript.LoadNextLevel();


        }
        if (other.CompareTag("DoorExit"))
        {

            Debug.Log("************************************************* I QUIT "); 


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
