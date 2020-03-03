using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{

      GameObject referenceObject;
      SoundTrack referenceScript;

      private float waitTime = 5f;

      private bool gameIsPaused = false;


      // Start is called before the first frame update
      void Start()
      {
            referenceObject = GameObject.FindWithTag("Soundtrack");
            referenceScript = referenceObject.GetComponent<SoundTrack>();
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
                  gameIsPaused = true;
                  pauseIt();

            }
            else
            {
                  //  gameIsPaused = false;
                  resumeIt();
            }
      }

      void pauseIt()
      {

            Debug.Log("----------------- stop it");

            // pauseMenuUI.SetActive(true);
            // gameIsPaused = true;


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

            if(gameIsPaused){

            Debug.Log("----------------- play it");
            waitTime = 5f;
            // pauseMenuUI.SetActive(false);
            gameIsPaused = false;

            if (GameVariables.musicOn)
            {
            referenceScript.UnPauseMusic();
            }
            Time.timeScale = 1f;
            // referenceObject = GameObject.FindWithTag("ObjectOne");
            // referenceScript = referenceObject.GetComponent<Gun>();
            // referenceScript.SetActive(false);
            }
      }
}
