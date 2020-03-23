using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{

      private float radius = 40f;  //20f
      private float force = 6000f; //  4000f;

      private int killCount = 0;


      public AudioSource source;
      public AudioClip clip;

      Animator myAnimator;

      private GameObject referenceObject;
      private DisplayText referenceScript;
      private int difference = 0;
      private bool alreadyRan = false; // to stop it from adding multiple levels completed


      private GameObject referenceObject1;
      private SpawnerSpecialWeapon referenceScript1;



      void Start()
      {
            myAnimator = GetComponent<Animator>();
            referenceObject = GameObject.FindWithTag("BallonCountDisplay");
            referenceScript = referenceObject.GetComponent<DisplayText>();
            referenceObject1 = GameObject.FindWithTag("SpecialWeapon");
            referenceScript1 = referenceObject1.GetComponent<SpawnerSpecialWeapon>();
      }




      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Dart"))
            {

                  explode();
            }
      }


      private void explode()
      {




            if (alreadyRan == false)
            {


                  referenceScript1.weaponActive = false; // weapon exploded, so we can start the countdopwn for next spawn

                  alreadyRan = true;

                  killCount = 0;

                  Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

                  source.PlayOneShot(clip);

                  foreach (Collider nearbyObject in colliders)
                  {
                        if (nearbyObject.CompareTag("Balloon"))
                        {
                              killCount++;
                              Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

                              if (rb != null)
                              {
                                    rb.AddExplosionForce(force, transform.position, radius);
                                    Destroy(rb.gameObject, .7f);
                              }
                        }
                  }


                  Score.totalPops += killCount; // add to display total pops
                  DisplayText.popsThisLevel += killCount; // add killcount to the popsthis level

                  // if we're at or past the max
                  if (DisplayText.popsThisLevel >= referenceScript.maxBalloons)
                  {

                        difference = DisplayText.popsThisLevel - referenceScript.maxBalloons;
                        Score.totalPops -= difference;

                        // set popsthislevel to max allowed
                        DisplayText.popsThisLevel = referenceScript.maxBalloons;

                        // update the score to the max allowed
                        Score.popsLastLevel = referenceScript.maxBalloons;

                        Score.myLevels++; // count the level as completed

                        // display text function can take us to the next scene
                        referenceScript.playOutroAnim();

                  }
                  else
                  {

                        playDie();
                  }
            }
      }


      public void playDie()
      {
            myAnimator.SetBool("AnimeDie", true);
      }

      public void destoryIt()
      {
            Destroy(gameObject);
      }

}
