using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpecialWeapon : MonoBehaviour
{
      public GameObject mySpecialWeapon; // which prefab we will be spawning
      public Transform spawnLocation1; // the location we will spawn the friendly

      public Transform spawnLocation2; // the location we will spawn the friendly

      public Transform spawnLocation3; // the location we will spawn the friendly

      private Transform[] spawnLocations;


      public float spawnDelay = 3.0f; // time to remain before spawning
      public float spawnInterval = 20.0f; // time to remain before spawning

      // private bool enemySpawned = false;



      // public GameObject myAnimatorObject;

      // Animator myAnimator;

      // private bool resetAnim = false;
      // private float waitTime = .3f;



      public bool weaponActive = false;
      private int thisSpawn;





      // Start is called before the first frame update
      void Start()
      {
            // myAnimator = myAnimatorObject.GetComponent<Animator>();


            spawnLocations = new Transform[3];

            spawnLocations[0] = spawnLocation1;
            spawnLocations[1] = spawnLocation2;
            spawnLocations[2] = spawnLocation3;

      }

      // Update is called once per frame
      void Update()
      {


            if (!weaponActive)
            {

                  spawnDelay -= Time.deltaTime;


                  // if we have less than 10 bummers
                  // if (Score.bummersLeft < 10)
                  // {
                  if (spawnDelay < 0)
                  {


                        thisSpawn = UnityEngine.Random.Range(0, 3);

                        // var friendly = Instantiate(mySpecialWeapon, spawnLocation1.position, spawnLocation1.transform.rotation);
                        var friendly = Instantiate(mySpecialWeapon, spawnLocations[thisSpawn].position, spawnLocations[thisSpawn].transform.rotation);
                        // GameVariables.bummers--;
                        spawnDelay = spawnInterval;

                        weaponActive = true;

                  }
                  // }

            }

            // --------------------------------



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

      // public void animateIt()
      // {
      //       Debug.Log("--------------------------------- animateIt ");
      //       myAnimator.SetBool("ShowAnimSpecWeap", true);
      //       resetAnim = true;

      // }








}












