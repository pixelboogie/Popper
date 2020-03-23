using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

      public AudioSource audioSource;
      private bool isWalking;
      public AudioClip steps;


      float Timer = 0.0f;
      CharacterController OVR;

      public float ClipTime = 0.3f;


      void Start () {
            OVR = GetComponent<CharacterController> ();

            isWalking = false;

      }
      void Update () {



            if (OVR.velocity.magnitude > .5f) {
                  if (Timer > ClipTime) {
                        playSteps ();
                        Timer = 0.0f;
                  }

                  Timer += Time.deltaTime;
            } else {
            }

      }

      void playSteps () {
            audioSource.Play ();
             }
      void stopSteps () {
            audioSource.Stop ();
           
      }

}