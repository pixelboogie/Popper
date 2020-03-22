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


      // ------------------------------------

      // public GameObject myAnimatorObject;
      // GameObject myAnimatorObject;
      Animator myAnimator;


      // private bool resetAnim = false;
      // private float waitTime = .3f;

      // ------------------------------------
      private GameObject referenceObject;
      private DisplayText referenceScript;
      private int difference = 0;
      private bool alreadyRan = false; // to stop it from adding multiple levels completed


      private GameObject referenceObject1;
      private SpawnerSpecialWeapon referenceScript1;

      // private int explodeCount;


      void Start()
      {
            // myAnimatorObject = GameObject.FindWithTag("AnimSpecWeap");
            // myAnimatorObject = myAnimatorObject;
            // myAnimator = myAnimatorObject.GetComponent<Animator>();
            myAnimator = GetComponent<Animator>();


            referenceObject = GameObject.FindWithTag("BallonCountDisplay");
            referenceScript = referenceObject.GetComponent<DisplayText>();

            referenceObject1 = GameObject.FindWithTag("SpecialWeapon");
            referenceScript1 = referenceObject1.GetComponent<SpawnerSpecialWeapon>();



      }


      private void Update()
      {
            // if (resetAnim)
            // {
            //       Debug.Log("--------------------------------- resetAnim ");
            //       waitTime -= Time.deltaTime;

            //       if (waitTime < 0)
            //       {

            //             Debug.Log("--------------------------------- waitTime ");
            //             myAnimator.SetBool("ShowAnimSpecWeap", false);
            //             resetAnim = false;
            //             waitTime = .3f;

            //       }
            // }
      }



      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Dart"))
            {
                  // Debug.Log("--------------------------------- OnTriggerEnter ");
                  // myAnimator.SetBool("ShowAnimSpecWeap", true);
                  // resetAnim = true;

                  // SpawnerSpecialWeapon.animateIt();
                  // SpawnerSpecialWeapon.animateIt();

                  explode();
            }
      }


      private void explode()
      {


            Debug.Log("---------------------- special weapon explode called");

            if (alreadyRan == false)
            {

                  Debug.Log("---------------------- special weapon  -alreadyRan == false");

                  referenceScript1.weaponActive = false; // weapon exploded, so we can start the countdopwn for next spawn


                  alreadyRan = true;

                  killCount = 0;

                  Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
                  // GameObject[] myObjects = Physics.OverlapSphere(transform.position, radius);

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

                        Debug.Log("------------------- special weapon---increment mylevels");
                        difference = DisplayText.popsThisLevel - referenceScript.maxBalloons;


                        //  Score.totalPops =  Score.totalPops + DisplayText.popsThisLevel - difference;
                        Score.totalPops -= difference;


                        // set popsthislevel to max allowed
                        DisplayText.popsThisLevel = referenceScript.maxBalloons;
                        //   Score.popsThisLevel = referenceScript.maxBalloons;


                        // update the score to the max allowed
                        // Score.popsLastLevel = Score.popsLastLevel + referenceScript.maxBalloons;
                        Score.popsLastLevel = referenceScript.maxBalloons;

                        // Score.totalPops = Score.totalPops + killCount - difference;
                        // Score.totalPops = Score.totalPops + referenceScript.maxBalloons;

                        //   Score.totalPops = Score.totalPops + referenceScript.maxBalloons; 

                        Score.myLevels++; // count the level as completed

                        // display text function can take us to the next scene
                        referenceScript.playOutroAnim();

                  }
                  else
                  {




                        //otherwise, just udate the pops this level
                        // DisplayText.popsThisLevel =  DisplayText.popsThisLevel + killCount;
                        // Score.totalPops = Score.totalPops + killCount;

                        // this.transform.localScale = new Vector3(0, 0, 0);  
                        // Destroy(gameObject, 2.5f);

                        playDie();
                  }
            }
      }


      public void playDie()
      {
            // Debug.Log("------------------------ playDie ");

            myAnimator.SetBool("AnimeDie", true);

      }

      public void destoryIt()
      {
            // Debug.Log("------------------------ destoryIt ");
            Destroy(gameObject);
      }




}
