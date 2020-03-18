using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class TipText : MonoBehaviour
{
      public TextMeshPro myTipText;


      private string[] Values;
      //     private GameObject[] Tips; 

      private int myTipNum;

      // [SerializeField] TextMeshProGUI m_tip;
      void Start()
      {

            Values = new string[7];
            Values[0] = "Practice makes perfect.";
            Values[1] = "Knowing the locations of AMMO BOXES is very important.";
            Values[2] = "Popping CLOWN BALLOONS increases your carrying capacity.";
            Values[3] = "It's a BUMMER when a balloon make it all the way to the end.";
            Values[3] = "It's GAME OVER when you reach 10 BUMMERS.";
            Values[4] = "Shoot down a HOT AIR BALLOON to undo a bummer.";
            Values[5] = "Completing levels increases your score. BUMMERS reduce your score.";
            Values[6] = "Complete more levels to earn new weapons.";

            myTipNum = UnityEngine.Random.Range(1, 7);

            myTipText.text = "Tip: " + Values[myTipNum];
   
      }


}
