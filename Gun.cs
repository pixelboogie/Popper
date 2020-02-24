using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Gun : MonoBehaviour
{

      public GameObject dartPrefab;
      public Transform barrelLocation;
      public float shotPower = 280000;

      public int loadedRounds = 10; // rounds on hand to use
      public int magCapacity = 10;



      public TextMeshPro ammoText;


      public AudioSource source;
      public AudioClip shot;
      public AudioClip click;
       public AudioClip reloadSound;

      void Update()
      {
            //Check if player is pulling the trigger
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                  Shoot();
            }

            // if (OVRInput.GetDown(OVRInput.Button.One))
                        if ((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch) > .8) && (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > .8))

            {
                  Reload();
            }


      }

      void Shoot()
      {

            //     var testVector = new Vector3(0, 0, 0);
            //Instansiate a new dart at the barrel location in the barrellocation rotation



            if (loadedRounds >= 1)
            {

                  source.PlayOneShot(shot);

                  var dart = Instantiate(dartPrefab, barrelLocation.position, barrelLocation.transform.rotation);
                  //     var dart =  Instantiate(dartPrefab, barrelLocation.position, testVector);

                  //Add force to the Dart rigidbody component
                  dart.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * Time.deltaTime * shotPower);
                  //Spinn the dart in the correct direction. if this is wrong for you try other values until it's correct
                  //   dart.transform.eulerAngles += new Vector3(0, 90, 90);

                  //  dart.transform.eulerAngles += new Vector3(0, 90, 0);
                  //   dart.transform.eulerAngles = new Vector3(0, 0, 0);

                  //  dart.transform.eulerAngles = new Vector3(90, 0, 0);

                  //      dart.transform.eulerAngles = new Vector3(-90, 0, 90);

                  loadedRounds--;

                  updateAmmoText();


                  //Destroy the dart after X seconds.
                  Destroy(dart, 3f);
            }else{
                    source.PlayOneShot(click);
            }
      }



      void Reload()
      {
       source.PlayOneShot(reloadSound);
         loadedRounds = magCapacity;
            updateAmmoText();
      }


      public void updateAmmoText()
      {
            ammoText.text = "Ammo: " + loadedRounds.ToString();
      }


}