using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BalloonRestart : MonoBehaviour
{
      public GameObject popSound;

      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Dart"))
            {
                  popSound.GetComponent<PopSound>().PlayPop();

                    // scale down so we can't see it
                  this.transform.localScale = new Vector3(0, 0, 0);

                  // reset the stats if we replay
                  // Score.totalPops = 0; 
                  // Score.myLevels = 0; 
                  // GameVariables.bummers = 0;

                  SceneManager.LoadScene("Scenes/01");
            }
      }
}
