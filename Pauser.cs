using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{

      GameObject referenceObject;
      SoundTrack referenceScript;

      private float waitTime = 5f;

      private bool lostVRFocus = false;


      void Start()
      {
            referenceObject = GameObject.FindWithTag("Soundtrack");
            referenceScript = referenceObject.GetComponent<SoundTrack>();

            
      }


      void Update()
      {

            waitTime -= Time.deltaTime;

            if (waitTime < 0)
            {
                  checkFocus();
            }


      }



      void checkFocus()
      {
            if (OVRManager.hasVrFocus == false)
            {
                  lostVRFocus = true;
                  pauseIt();

            }
            else
            {
                
                  resumeIt();
            }
      }

      void pauseIt()
      {

            if (GameVariables.musicOn)
            {
                  referenceScript.PauseMusic();
            }
            Time.timeScale = 0f;
      }

      void resumeIt()
      {

            if(lostVRFocus){

     
            waitTime = 5f;
    
            lostVRFocus = false;

            if (GameVariables.musicOn)
            {
            referenceScript.UnPauseMusic();
            }

            if(PauseMenu.gameIsPaused == false){
            Time.timeScale = 1f;
            }

            }
      }
}
