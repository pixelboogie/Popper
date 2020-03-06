using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCollision4 : MonoBehaviour
{

      GameObject referenceObject;
      Gun referenceScript;

      public AudioSource source;

      public  GameObject myAnimatorObject;
      Animator myAnimator;

      private bool resetAnim = false;
      private float waitTime = .3f;

      void Start()
      {
            referenceObject = GameObject.FindWithTag("ObjectOne");
            referenceScript = referenceObject.GetComponent<Gun>();

            myAnimator = myAnimatorObject.GetComponent<Animator>();

      }


      void Update()
      {

            if (resetAnim)
            {

                  waitTime -= Time.deltaTime;

                  if (waitTime < 0)
                  {
                         myAnimator.SetBool("ShowAmmoAnim", false);
                        resetAnim = false;

                  }
            }

      }



      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Player"))
            {

                  Debug.Log("-------------------------------- Got it");
                  myAnimator.SetBool("ShowAmmoAnim", true);
                  resetAnim = true;
                  waitTime = .3f;

                  referenceScript.carryRounds = referenceScript.carryCapacity;  // fill up carried round
                  referenceScript.loadedRounds = referenceScript.magCapacity; // fill up loaded rounds

                  referenceScript.updateAmmoText();

                  source.Play();

            }
      }

      private void OnTriggerExit(Collider other)
      {

            if (other.CompareTag("Player"))
            {
                  myAnimator.SetBool("ShowAmmoAnim", false);
                    waitTime = .3f;
            }

      }



}
