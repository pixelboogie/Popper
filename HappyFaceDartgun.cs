﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HappyFaceDartgun : MonoBehaviour
{

    public TextMeshPro ammoText;
//     public GameObject Blaster;

//     public int roundsCount;

    // Start is called before the first frame update



      GameObject referenceObject;
      DartGun referenceScript;



    void Start()
    {
        
          referenceObject = GameObject.FindWithTag("ObjectOne");
          referenceScript = referenceObject.GetComponent<DartGun>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dart"))
        {

            // health--;
            // ballonCountDisplay.GetComponent<DisplayText>().BallonPopIncrease();
            // popSound.GetComponent<PopSound>().PlayPop();
            // if (health <= 0)
            // {
            //     Destroy(this.gameObject);
            // }

                  //  Blaster.GetComponent.<Blaster>.roundsCount = 10;
                  //  Blaster.roundsCount = 10;
            //     ammoText.text = "Ammo: " + 10000.ToString();
            //  referenceScript.roundsCount = 10;
                referenceScript.magCapacity = 20; // extend mag capacity
                referenceScript.loadedRounds = 20;  // and reload the gun
                referenceScript.updateAmmoText();
                  Destroy(this.gameObject);
        }
    }
}