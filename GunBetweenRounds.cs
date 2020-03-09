using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunBetweenRounds : MonoBehaviour
{

      public GameObject dartPrefab;
      public Transform barrelLocation;
      public float shotPower = 180000;
      // public int loadedRounds = 100000; // rounds on hand to use
      // public int magCapacity = 10000000;

      // public int carryRounds = 20; // rounds carried (not in mag)
      // public int carryCapacity = 20;




      public AudioSource source;
      public AudioClip shot;
      // public AudioClip click;
      // public AudioClip reloadSound;

      // GameObject referenceObject;
      


      private void Start()
      {

      }
      void Update()
      {

   

            //Check if player is pulling the trigger
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                  Shoot();
            }



      }

      void Shoot()
      {
                        source.PlayOneShot(shot);
                        var dart = Instantiate(dartPrefab, barrelLocation.position, barrelLocation.transform.rotation);
                        dart.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * Time.deltaTime * shotPower);
                        Destroy(dart, 3f);
       }



}