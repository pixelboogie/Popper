using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{

      GameObject referenceObject;
      SoundTrack referenceScript;

      private float waitTime = 5f;

      private bool lostVRFocus = false;


      // GameObject referenceObject2;
      // PauseMenu referenceScript2;

      // Start is called before the first frame update
      void Start()
      {
            referenceObject = GameObject.FindWithTag("Soundtrack");
            referenceScript = referenceObject.GetComponent<SoundTrack>();

            // referenceObject2 = GameObject.FindWithTag("PauseMenu");
            // referenceScript2 = referenceObject2.GetComponent<PauseMenu>();
      }

      // Update is called once per frame
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
                  //  lostVRFocus = false;
                  resumeIt();
            }
      }

      void pauseIt()
      {

            // Debug.Log("----------------- stop it");

            // pauseMenuUI.SetActive(true);
            // lostVRFocus = true;


            // referenceObject = GameObject.FindWithTag("ObjectOne");
            // referenceScript = referenceObject.GetComponent<Gun>();
            // referenceScript.SetActive(true);
            if (GameVariables.musicOn)
            {
                  referenceScript.PauseMusic();
            }
            Time.timeScale = 0f;
      }

      void resumeIt()
      {

            if(lostVRFocus){

            // Debug.Log("----------------- play it");
            waitTime = 5f;
            // pauseMenuUI.SetActive(false);
            lostVRFocus = false;

            if (GameVariables.musicOn)
            {
            referenceScript.UnPauseMusic();
            }

            if(PauseMenu.gameIsPaused == false){
            Time.timeScale = 1f;
            }
            // referenceObject = GameObject.FindWithTag("ObjectOne");
            // referenceScript = referenceObject.GetComponent<Gun>();
            // referenceScript.SetActive(false);
            }
      }
}
