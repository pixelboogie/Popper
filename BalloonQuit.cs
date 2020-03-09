using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BalloonQuit : MonoBehaviour
{
      public GameObject popSound;

      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Dart"))
            {
                  popSound.GetComponent<PopSound>().PlayPop();

                    // scale down so we can't see it
                  this.transform.localScale = new Vector3(0, 0, 0);

    // save any game data here
#if UNITY_EDITOR
    
         UnityEditor.EditorApplication.isPlaying = false;
#else
                  Application.Quit();
#endif

            }
      }
}
