using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunBetweenRounds : MonoBehaviour
{

      public GameObject dartPrefab;
      public Transform barrelLocation;
      public float shotPower = 180000;



      public AudioSource source;
      public AudioClip shot;


      private float waitTime = 2f;  // wait a bit before making gun active

      private bool gunActive = false; // gun turned off




      private void Start()
      {

      }
      void Update()
      {



            // after a bit, make gun active
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                  gunActive = true;
            }


            if (gunActive)
            {
                  //Check if player is pulling the trigger
                  if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                  {
                        Shoot();
                  }
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