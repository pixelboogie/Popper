﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Score : MonoBehaviour
{

      public static int totalPops = 0;

      public static int myLevels = 0;

       public static int bummersLeft = 10;

      public TextMeshPro TotalPopsText;

     public TextMeshPro LevelsText;

          public TextMeshPro FinalScoreText;

 public TextMeshPro BummersText;

private int ml = 1; // minimum for score calc
private int tp = 1; // minimum for score calc
private int bl = 1; // minimum for score calc


    // Start is called before the first frame update
    void Start()
    {
      //   totalPops = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
      //   if(totalPops>0){
      //         Debug.Log("totalPops is: " + totalPops);
      //   }

      TotalPopsText.text = totalPops.ToString();
      LevelsText.text = myLevels.ToString();

       BummersText.text = bummersLeft.ToString();

       if(myLevels <=1){
            ml = 1;
       }else{
             ml = myLevels;
       }

       if(totalPops <=1){
            tp = 1;
       }else{
             tp = totalPops;
       }
       if(bummersLeft <=1){
            bl = 1;
       }else{
             bl = bummersLeft;
       }

      int scoreCalculation =  ml * tp * bl;
       FinalScoreText.text = scoreCalculation.ToString();


    }




}
