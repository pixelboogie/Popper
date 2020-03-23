using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HappyFace : MonoBehaviour
{


      public TextMeshPro ammoText;

      GameObject referenceObject;
      Blaster referenceScript;

      GameObject nonTargetObject;
      NonTarget nonTargetScript;
      private Vector3 startPosition;

      public float throttle = .5f; // speed it rises

      float dist; // track dist balloon goes up before destroying it

      private int carryCapacityBoost = 5; // how much to increase carrycapacity if popped

      private int magCapacityBoost = 5; // how much to increase magcapacity if popped

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
            referenceScript = referenceObject.GetComponent<Blaster>();
            startPosition = transform.position;
            myAnimator = GetComponent<Animator>();
            source.PlayOneShot(nonTargetSpawnClip);
      }


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
                  explode();
            }
      }




      private void explode()
      {
            if (!alreadyExploded)
            {
                  alreadyExploded = true;
                  source.PlayOneShot(nonTargetDieClip);
                  playDie();

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
