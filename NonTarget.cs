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

      private int thisSpawn;

      void Start()
      {
         spawnLocations = new Transform[3];   
            spawnLocations[0]=friendlyLocation1;
            spawnLocations[1]=friendlyLocation2;
            spawnLocations[2]=friendlyLocation3;

      }


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




      }



      public void spawnOne()
      {


          thisSpawn = UnityEngine.Random.Range(0,3);

            

            var friendly = Instantiate(friendlyPrefab, spawnLocations[thisSpawn].position, spawnLocations[thisSpawn].transform.rotation);

      }

      public void playDie()
      {

      }



}
