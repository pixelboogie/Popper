using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

      public static bool gameIsPaused = false;
      public GameObject pauseMenuUI;

      // GameObject referenceObject;
      // Gun referenceScript;


      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {
            if (OVRInput.GetDown(OVRInput.RawButton.X))
            // if ((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch) > .8) && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > .8))
            {
                  if (gameIsPaused)
                  {
                        resume();
                  }
                  else
                  {
                        pause();
                  }
            }

      }

      void pause()
      {
            pauseMenuUI.SetActive(true);
            gameIsPaused = true;
            Time.timeScale = 0f;

            // referenceObject = GameObject.FindWithTag("ObjectOne");
            // referenceScript = referenceObject.GetComponent<Gun>();
            // referenceScript.SetActive(true);


      }

      void resume()
      {
            pauseMenuUI.SetActive(false);
            gameIsPaused = false;
            Time.timeScale = 1f;

            // referenceObject = GameObject.FindWithTag("ObjectOne");
            // referenceScript = referenceObject.GetComponent<Gun>();
            // referenceScript.SetActive(false);
      }
}
