using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HappyFaceGun : MonoBehaviour
{
      public TextMeshPro ammoText;
      GameObject referenceObject;
      Gun referenceScript;
      GameObject nonTargetObject;
      NonTarget nonTargetScript;
      private Vector3 startPosition;
      public float throttle = .3f; // speed it rises
      float dist; // track dist balloon goes up before destroying it

      private int carryCapacityBoost = 10; // how much to increase carrycapacity if popped

      private int magCapacityBoost = 10; // how much to increase magcapacity if popped

      void Start()
      {

            referenceObject = GameObject.FindWithTag("ObjectOne");
            referenceScript = referenceObject.GetComponent<Gun>();

            nonTargetObject = GameObject.FindWithTag("nonTarget");
            nonTargetScript = nonTargetObject.GetComponent<NonTarget>();

                        startPosition = transform.position;

      }

      // Update is called once per frame
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

                  referenceScript.carryCapacity = referenceScript.carryCapacity + carryCapacityBoost; // boost carry capacity
                  referenceScript.magCapacity = referenceScript.magCapacity + magCapacityBoost; // extend mag capacity
                  referenceScript.loadedRounds = referenceScript.magCapacity;  // and reload the gun

                  referenceScript.updateAmmoText();
                  nonTargetScript.playDie();
                  Destroy(this.gameObject);
            }
      }
}
