using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NonTarget : MonoBehaviour
{

      public GameObject friendlyPrefab; // which prefab we will be spawning
      public Transform friendlyLocation1; // the location we will spawn the friendly
      public Transform friendlyLocation2; // the location we will spawn the friendly
      public Transform friendlyLocation3; // the location we will spawn the friendly

      public Transform[] spawnLocations;




      public float delayTime = 8.0f; // time to remain before spawning the friendly
      public float spawnInterval = 20.0f; // for each subsequent spawn
      private bool friendlySpawned = false;

      // public AudioSource source;
      // public AudioClip nonTargetClip;
      // public AudioClip nonTargetDieClip;

      private int thisSpawn;


      // Start is called before the first frame update
      void Start()
      {
            // var friendly = Instantiate(friendlyPrefab, friendlyLocation.position, friendlyLocation.transform.rotation);

            spawnLocations = new Transform[3];   
            
            spawnLocations[0]=friendlyLocation1;
            spawnLocations[1]=friendlyLocation2;
            spawnLocations[2]=friendlyLocation3;


      }

      // Update is called once per frame
      void Update()
      {


            if (friendlySpawned == false)
            {
                  delayTime -= Time.deltaTime;

                  if (delayTime < 0)
                  {
                        delayTime = spawnInterval;
                        spawnOne();
                  }
            }

            // if (friendlySpawned == true)
            // {
            //       delayTime -= Time.deltaTime;

            //       if (delayTime < 0)
            //       {
            //             spawnOne();
            //       }
            // }


      }



      public void spawnOne()
      {


      //  thisSpawn = 2;
          thisSpawn = UnityEngine.Random.Range(0,3);

             Debug.Log("------------------------ thisSpawn: " + thisSpawn);

            // var friendly = Instantiate(friendlyPrefab, friendlyLocation.position, friendlyLocation.transform.rotation);
            var friendly = Instantiate(friendlyPrefab, spawnLocations[thisSpawn].position, spawnLocations[thisSpawn].transform.rotation);
            // friendlySpawned = true;
            // source.PlayOneShot(nonTargetClip);
      }

      public void playDie()
      {

            //   Debug.Log("------------------------ playDie ");

            // myAnimator.SetBool("AnimateIt", true);
            // waitTime = .3f;
            // resetAnim = true;

            // source.PlayOneShot(nonTargetDieClip);
      }



}
