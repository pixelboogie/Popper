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
            Values[0] = "Nothing will help.";
            Values[1] = "Knowing the location of Ammo Boxes is very important.";
            Values[2] = "Popping Clown balloons increases your carrying capacity.";
            Values[3] = "It's a BUMMER when a balloon make it all the way to the end.";
            Values[3] = "If you get 10 BUMMERS, the game is over.";
            Values[4] = "Shoot down a hot air balloon to undo a bummer.";
            Values[5] = "Completing levels increses your score. Bummers reduce your score.";
            Values[6] = "Complete more levels to earn new weapons.";
     
     

            //      Values[0] = "Tip #0: Nothing will help.";
            // Values[1] = "Tip #2: Knowing the location of Ammo Boxes is very important.";
            // Values[2] = "Tip #3: Popping Clown balloons increases your carrying capacity.";
            // Values[3] = "Tip #4: It's a BUMMER when a balloon make it all the way to the end.";
            // Values[3] = "Tip #5: If you get 10 BUMMERS, the game is over.";
            // Values[4] = "Tip #6: Shoot down a hot air balloon to undo a bummer.";
            // Values[5] = "Tip #7: Completing levels increses your score. Bummers reduce your score.";
            // Values[6] = "Tip #8: Complete more levels to earn new weapons.";

            myTipNum = UnityEngine.Random.Range(1, 6);

            //  myTipNum =  1;

            //    GetComponent<TextMeshPro>.text = "Tip #1: Got it!";
            myTipText.text = "Tip (" + Values[myTipNum] + ")";
            //   myTipText.text = 
      }


}
