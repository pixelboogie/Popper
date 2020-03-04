using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCollision4 : MonoBehaviour
{

      GameObject referenceObject;
      Gun referenceScript;

      public AudioSource source;



      GameObject myAnimatorObject;
      Animator myAnimator;

      private bool resetAnim = false;
      private float waitTime = .3f;


      // Start is called before the first frame update
      void Start()
      {
            referenceObject = GameObject.FindWithTag("ObjectOne");
            referenceScript = referenceObject.GetComponent<Gun>();

            myAnimatorObject = GameObject.FindWithTag("AnimAmmo");
            // myAnimatorScript = myAnimatorObject.GetComponent<AnimAmmo>();
            myAnimator = myAnimatorObject.GetComponent<Animator>();

      }

      // Update is called once per frame
      void Update()
      {



            if (resetAnim)
            {

                  // Debug.Log("*********************************************** resetAnim ");

                  waitTime -= Time.deltaTime;

                  if (waitTime < 0)
                  {

                        // Debug.Log("*********************************************** waitTime ");
                        myAnimator.SetBool("ShowAmmoAnim", false);
                        resetAnim = false;

                  }
            }

      }



      private void OnTriggerEnter(Collider other)
      {

            if (other.CompareTag("Player"))
            {

                  //   myAnimatorScript.playAnim();
                  //   myAnimator.SetTrigger("ShowAnimAmmo");


                  // Debug.Log("*********************************************** Colllision ");
                  myAnimator.SetBool("ShowAmmoAnim", true);
                  resetAnim = true;
                  waitTime = .3f;


                  // Time.timeScale = 0;

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
