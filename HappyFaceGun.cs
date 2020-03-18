﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HappyFaceGun : MonoBehaviour
{
      public TextMeshPro ammoText;
      GameObject referenceObject;
      Gun referenceScript;
      // GameObject nonTargetObject;
      // NonTarget nonTargetScript;
      private Vector3 startPosition;
      public float throttle = 1.5f; // speed it rises
      float dist; // track dist balloon goes up before destroying it

      private int carryCapacityBoost = 5; // how much to increase carrycapacity if popped

      private int magCapacityBoost = 5; // how much to increase magcapacity if popped


  // ------------------------------------
 private bool alreadyExploded = false;

      public AudioSource source;
   public AudioClip nonTargetDieClip;
      public AudioClip nonTargetSpawnClip;

    
      public GameObject myAnimatorObject;
      Animator myAnimator;

      private bool resetAnim = false;






      void Start()
      {

            referenceObject = GameObject.FindWithTag("ObjectOne");
            referenceScript = referenceObject.GetComponent<Gun>();

            // nonTargetObject = GameObject.FindWithTag("nonTarget");
            // nonTargetScript = nonTargetObject.GetComponent<NonTarget>();

            startPosition = transform.position;

            myAnimator = GetComponent<Animator>();

                     source.PlayOneShot(nonTargetSpawnClip);

      }

      // Update is called once per frame
      void Update()
      {
            transform.Translate(Vector3.up * Time.deltaTime * throttle);

            dist = Vector3.Distance(startPosition, transform.position);
            if (dist > 25)
            {
                  Destroy(gameObject);
            }
      }

      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Dart"))
            {

                  referenceScript.carryCapacity = referenceScript.carryCapacity + carryCapacityBoost; // extend carry capacity
                  referenceScript.magCapacity = referenceScript.magCapacity + magCapacityBoost; // extend mag capacity
                  referenceScript.loadedRounds = referenceScript.magCapacity;  // reload the gun
                     referenceScript.carryRounds = referenceScript.carryCapacity;  // fill carried load

                  referenceScript.updateAmmoText();
                  // nonTargetScript.playDie();
                  // Destroy(this.gameObject);
                  explode();
            }
      }


      private void explode()
      {

            // Debug.Log("++++++++++++++++ explode called");

            if (!alreadyExploded)
            {


                  // Debug.Log("++++++++++++++++ explode if statement called");




                  alreadyExploded = true;

                  source.PlayOneShot(nonTargetDieClip);

                  // Debug.Log("________________________Explode");

                  playDie();

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
