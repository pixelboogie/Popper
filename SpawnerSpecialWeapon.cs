using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpecialWeapon : MonoBehaviour
{
      public GameObject mySpecialWeapon; // which prefab we will be spawning
      public Transform spawnLocation; // the location we will spawn the friendly
      public float spawnDelay = 3.0f; // time to remain before spawning
      public float spawnInterval = 20.0f; // time to remain before spawning

      // private bool enemySpawned = false;



      // public GameObject myAnimatorObject;

      // Animator myAnimator;

      // private bool resetAnim = false;
      // private float waitTime = .3f;


      // Start is called before the first frame update
      void Start()
      {
            // myAnimator = myAnimatorObject.GetComponent<Animator>();
      }

      // Update is called once per frame
      void Update()
      {

            spawnDelay -= Time.deltaTime;


            // if we have less than 10 bummers
            // if (Score.bummersLeft < 10)
            // {
            if (spawnDelay < 0)
            {
                  var friendly = Instantiate(mySpecialWeapon, spawnLocation.position, spawnLocation.transform.rotation);
                  // GameVariables.bummers--;
                  spawnDelay = spawnInterval;
            }
            // }



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










      

