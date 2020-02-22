using UnityEngine;
using TMPro;

public class DartGun : MonoBehaviour
{

      public GameObject dartPrefab;
      public Transform barrelLocation;
      public float shotPower = 180000;
      public int roundsCount = 10; // rounds on hand to use
      public int maxRounds = 10;


      public TextMeshPro ammoText;

      void Update()
      {
            //Check if player is pulling the trigger
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                  Shoot();
            }

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                  Reload();
            }


      }

      void Shoot()
      {

            //     var testVector = new Vector3(0, 0, 0);
            //Instansiate a new dart at the barrel location in the barrellocation rotation



            if (roundsCount >= 1)
            {

                  roundsCount--;



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



                  ammoText.text = "Ammo: " + roundsCount.ToString();


                  //Destroy the dart after X seconds.
                  Destroy(dart, 3f);
            }
      }



      void Reload()
      {

            roundsCount = maxRounds;
            ammoText.text = "Ammo: " + roundsCount.ToString();
      }
}