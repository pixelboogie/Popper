using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blaster : MonoBehaviour {

      public GameObject dartPrefab;
      public Transform barrelLocation;
      public float shotPower = 700000;

      public int loadedRounds = 10; // rounds on hand to use
      public int magCapacity = 10;

      public TextMeshPro ammoText;

      public AudioSource source;
      public AudioClip shot;
      public AudioClip click;
      public AudioClip reloadSound;

      void Update () {
            //Check if player is pulling the trigger
            if (OVRInput.GetDown (OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)) {
                  Shoot ();
            }

            // if (OVRInput.GetDown(OVRInput.Button.One))
            if ((OVRInput.Get (OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch) >.8) && (OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) >.8))

            {
                  Reload ();
            }

      }

      void Shoot () {

            if (loadedRounds >= 1) {

                  source.PlayOneShot (shot);

                  var dart = Instantiate (dartPrefab, barrelLocation.position, barrelLocation.transform.rotation);
                  //     var dart =  Instantiate(dartPrefab, barrelLocation.position, testVector);

                  //Add force to the Dart rigidbody component
                  dart.GetComponent<Rigidbody> ().AddForce (barrelLocation.forward * Time.deltaTime * shotPower);

                  loadedRounds--;

                  updateAmmoText ();

                  //Destroy the dart after X seconds.
                  Destroy (dart, 3f);
            }
      }

      void Reload () {

            loadedRounds = magCapacity;
            updateAmmoText ();

            if (source.isPlaying == true) {

            } else {
                  source.PlayOneShot (reloadSound);
            }
      }

      public void updateAmmoText () {
       ammoText.text = loadedRounds.ToString ();
      }

}