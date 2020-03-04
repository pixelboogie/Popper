using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCollision : MonoBehaviour
{

      GameObject referenceObject;
      DartGun referenceScript;

      public AudioSource source;

      GameObject myAnimatorObject;
      AnimAmmo myAnimatorScript;

      // Start is called before the first frame update
      void Start()
      {
            referenceObject = GameObject.FindWithTag("ObjectOne");
            referenceScript = referenceObject.GetComponent<DartGun>();

            myAnimatorObject = GameObject.FindWithTag("AnimAmmo");
            myAnimatorScript = myAnimatorObject.GetComponent<AnimAmmo>();
                  //  myAnimator = GetComponent<Animator>();
                  //   myAnimator = myAnimatorObject.GetComponent<AnimAmmo>();
                   
      }

      // Update is called once per frame
      void Update()
      {

      }



      private void OnTriggerEnter(Collider other)
      {

            if (other.CompareTag("Player"))
            {

                     myAnimatorScript.playAnim();
                  Debug.Log("*********************************************** Colllision ");
                  // Time.timeScale = 0;

                  referenceScript.carryRounds = referenceScript.carryCapacity;  // fill up carried round
                  referenceScript.loadedRounds = referenceScript.magCapacity; // fill up loaded rounds

                  referenceScript.updateAmmoText();

                  source.Play();
// 
              

            }
      }

}
