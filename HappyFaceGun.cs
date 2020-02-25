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

    void Start()
    {
        
          referenceObject = GameObject.FindWithTag("ObjectOne");
          referenceScript = referenceObject.GetComponent<Gun>();

            nonTargetObject = GameObject.FindWithTag("nonTarget");
          nonTargetScript = nonTargetObject.GetComponent<NonTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dart"))
        {

                referenceScript.magCapacity = 20; // extend mag capacity
                referenceScript.loadedRounds = 20;  // and reload the gun
                referenceScript.updateAmmoText();

                 nonTargetScript.playDie();
                 
                  Destroy(this.gameObject);
        }
    }
}
