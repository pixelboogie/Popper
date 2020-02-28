using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DartGun : MonoBehaviour
{

      public GameObject dartPrefab;
      public Transform barrelLocation;
      public float shotPower = 180000;
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
                  //Instansiate a new dart at the barrel location in the barrellocation rotation

                  if (loadedRounds >= 1)
                  {


                        source.PlayOneShot(shot);

                        var dart = Instantiate(dartPrefab, barrelLocation.position, barrelLocation.transform.rotation);
                        //     var dart =  Instantiate(dartPrefab, barrelLocation.position, testVector);

                        //Add force to the Dart rigidbody component
                        dart.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * Time.deltaTime * shotPower);
                        loadedRounds--;

                        // updateAmmoText();

                        //Destroy the dart after X seconds.
                        Destroy(dart, 3f);
                  }
                  else
                  {
                        source.PlayOneShot(click, 1f);
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
            // ammoText.text = "Ammo: " + loadedRounds.ToString();
            ammoText.text = loadedRounds.ToString();
            carryRoundsText.text = carryRounds.ToString();
            carryCapacityText.text = carryCapacity.ToString();

      }


}