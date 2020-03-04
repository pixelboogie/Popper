using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonTarget : MonoBehaviour
{

      public GameObject friendlyPrefab; // which prefab we will be spawning
      public Transform friendlyLocation; // the location we will spawn the friendly

      private float timeLeft = 5.0f; // time to remain before spawning the friendly
      private float resetInterval = 30.0f; // for each subsequent spawn
      private bool friendlySpawned = false;

      public AudioSource source;
      public AudioClip nonTargetClip;
      public AudioClip nonTargetDieClip;



      // ------------------------------------
      public GameObject myAnimatorObject;
      Animator myAnimator;

      private bool resetAnim = false;
      private float waitTime = .3f;



      // Start is called before the first frame update
      void Start()
      {
            // var friendly = Instantiate(friendlyPrefab, friendlyLocation.position, friendlyLocation.transform.rotation);

            myAnimator = myAnimatorObject.GetComponent<Animator>();

      }

      // Update is called once per frame
      void Update()
      {


            if (friendlySpawned == false)
            {
                  timeLeft -= Time.deltaTime;

                  if (timeLeft < 0)
                  {
                        timeLeft = resetInterval;
                        spawnOne();
                  }
            }

            // if (friendlySpawned == true)
            // {
            //       timeLeft -= Time.deltaTime;

            //       if (timeLeft < 0)
            //       {
            //             spawnOne();
            //       }
            // }



            if (resetAnim)
            {
                        Debug.Log("------------------------ resetAnim ");
                  waitTime -= Time.deltaTime;

                  if (waitTime < 0)
                  {

                           Debug.Log("------------------------ waitTime ");
                        myAnimator.SetBool("AnimateIt", false);
                        resetAnim = false;

                  }
            }







      }



      public void spawnOne()
      {
            var friendly = Instantiate(friendlyPrefab, friendlyLocation.position, friendlyLocation.transform.rotation);
            // friendlySpawned = true;
            source.PlayOneShot(nonTargetClip);
      }

      public void playDie()
      {

              Debug.Log("------------------------ playDie ");

            myAnimator.SetBool("AnimateIt", true);
            waitTime = .3f;
            resetAnim = true;

            source.PlayOneShot(nonTargetDieClip);
      }



}
