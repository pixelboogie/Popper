﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
      public GameObject dartPrefab;
      public Transform barrelLocation;
      public float shotPower = 200000;

      public int loadedRounds = 10; // rounds on hand to use
      public int magCapacity = 10;

      public int carryRounds = 20; // rounds carried (not in mag)
      public int carryCapacity = 20;
      public TextMeshPro ammoText;

      public TextMeshPro carryRoundsText;
      public TextMeshPro carryCapacityText;

      public AudioSource source;
      public AudioClip shot;
      public AudioClip click;
      public AudioClip reloadSound;

            GameObject referenceObject;

            
      Color offWhite;

      private void Start()
      {
            // ref this so we can change color when low ammo
            referenceObject = GameObject.FindWithTag("ammoText");

                ColorUtility.TryParseHtmlString("#D1D1D1", out offWhite);
      }


      void Update()
      {
            updateAmmoText();

            //Check if player is pulling the trigger
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                  Shoot();
            }

            if (OVRInput.GetDown(OVRInput.Button.One))
            // if ((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch) > .8) && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > .8))

            {
                  Reload();
            }


      }

      void Shoot()
      {



            if (PauseMenu.gameIsPaused == false)
            {

                  if (loadedRounds >= 1)
                  {

                        source.PlayOneShot(shot);

                        var dart = Instantiate(dartPrefab, barrelLocation.position, barrelLocation.transform.rotation);


                        //Add force to the Dart rigidbody component
                        dart.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * Time.deltaTime * shotPower);
                        loadedRounds--;

                        // updateAmmoText();


                        //Destroy the dart after X seconds.
                        Destroy(dart, 0.3f);
                  }
                  else
                  {
                        source.PlayOneShot(click);
                  }
            }
      }



      void Reload()
      {

            if (carryRounds >= 1)
            {
                  if (carryRounds < magCapacity)
                  {
                        loadedRounds = loadedRounds + carryRounds;
                        carryRounds = 0;
                  }
                  else
                  {
                        loadedRounds = magCapacity;
                        carryRounds = carryRounds - magCapacity;
                  }

                  //      updateAmmoText();
            }

            if (source.isPlaying == true)
            {

            }
            else
            {
                  source.PlayOneShot(reloadSound);
            }

      }


      public void updateAmmoText()
      {

            if (loadedRounds < 6)
            {
                  referenceObject.GetComponent<TextMeshPro>().color = Color.red;
            }else{
                 referenceObject.GetComponent<TextMeshPro>().color = offWhite;
            }
            
            ammoText.text = loadedRounds.ToString();
            carryRoundsText.text = carryRounds.ToString();
            carryCapacityText.text = carryCapacity.ToString();

      }


}