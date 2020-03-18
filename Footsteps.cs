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

      // Start is called before the first frame update
      void Start () {
            OVR = GetComponent<CharacterController> ();

            isWalking = false;

      }

      // Update is called once per frame
      void Update () {

            //     if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            //    OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            //  if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)!= (0.0, 0.0)){

            //playSteps();
            //  Debug.Log("+++++++++++++++++++++++++++++++++++++++++Joystick +++  " +    OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick));

            //  if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp)){
            //   isWalking = true;
            //Debug.Log("+++++++++++++++++++++++++++++++++++++++++Joystick +++  "); 
            //   audioSource.Play();   
            //   }else{
            //   audioSource.Stop();   
            //   }

            //if (OVR.isGrounded == true && OVR.velocity.magnitude > 2.0f) {
            // if (OVR.isGrounded == false) {
            if (OVR.velocity.magnitude > .5f) {
                  // if (Timer > 0.3f) {
                  if (Timer > ClipTime) {
                        //		AkSoundEngine.PostEvent ("Footsteps", gameObject);
                        // stopSteps();
                        playSteps ();
                        Timer = 0.0f;
                  }

                  Timer += Time.deltaTime;
            } else {
                  //  playSteps();

            }

      }

      void playSteps () {
            audioSource.Play ();
            //   audioSource.PlayOneShot(steps);
            // Debug.Log ("+++++++++++++++++++++++++++++++++++++++++ PLAY STEPS +++  ");
      }
      void stopSteps () {
            audioSource.Stop ();
            // Debug.Log ("+++++++++++++++++++++++++++++++++++++++++ STOP STEPS +++  ");
      }
      // void playScream () {
      //          audioSource.clip = scream;

      //            audioSource.Play ();
      //       // Debug.Log ("+++++++++++++++++++++++++++++++++++++++++ STOP STEPS +++  ");
      // }
}