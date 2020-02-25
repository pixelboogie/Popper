using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCollision4 : MonoBehaviour
{

      GameObject referenceObject;
      Gun referenceScript;

        public AudioSource source; 



      // Start is called before the first frame update
      void Start()
      {
            referenceObject = GameObject.FindWithTag("ObjectOne");
            referenceScript = referenceObject.GetComponent<Gun>();
      }

      // Update is called once per frame
      void Update()
      {

      }



      private void OnTriggerEnter(Collider other)
      {

            if (other.CompareTag("Player"))
            {
                  // Debug.Log("*********************************************** Colllision ");
                  // Time.timeScale = 0;

                  referenceScript.carryRounds = referenceScript.carryCapacity;  // fill up carried round
                  referenceScript.loadedRounds = referenceScript.magCapacity; // fill up loaded rounds

                  referenceScript.updateAmmoText();

                  source.Play();

            }
      }

}
