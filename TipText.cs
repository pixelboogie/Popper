using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class TipText : MonoBehaviour
{
      public TextMeshPro myTipText;


      private string[] Tips;
      //     private GameObject[] Tips; 

      private int myTipNum;

      // [SerializeField] TextMeshProGUI m_tip;
      void Start()
      {

            Tips = new string[8];
            Tips[0] = "Practice makes perfect.";
            Tips[1] = "Knowing the locations of AMMO BOXES is very important.";
            Tips[2] = "Popping CLOWN BALLOONS increases your carrying capacity.";
            Tips[3] = "It's a BUMMER when a balloon make it all the way to the end.";
            Tips[3] = "It's GAME OVER when you reach 10 BUMMERS.";
            Tips[4] = "Shoot down a HOT AIR BALLOON to undo a bummer.";
            Tips[5] = "Completing levels increases your score. BUMMERS reduce your score.";
            Tips[6] = "Complete more levels to earn new weapons.";
            Tips[7] = "Complete all level to become a POP SHOT.";

            myTipNum = UnityEngine.Random.Range(1, 8);

            myTipText.text = "Tip: " + Tips[myTipNum];
   
      }


}
