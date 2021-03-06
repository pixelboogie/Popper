﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Score : MonoBehaviour
{

      public static int totalPops = 0;
      public static int popsLastLevel = 0;

      public static int popsRemaining;
      public static int myLevels = 0;


      public static int scoreCalculation;



      private int bummersAllowed = 10;
      // public static int bummers = 0;
      public static int bummersLeft;


      public TextMeshPro TotalPopsText;

      public TextMeshPro LevelsText;

      public TextMeshPro FinalScoreText;

      public TextMeshPro BummersText;

      public TextMeshPro PopsLastLevelText;


      public TextMeshPro popsRemainingText;

      private int ml = 1; // minimum for score calc
      private int tp = 1; // minimum for score calc
      private int bl = 1; // minimum for score calc




      void Start()
      {

            bummersLeft = bummersAllowed - GameVariables.bummers;

      }


      void Update()
      {

            bummersLeft = bummersAllowed - GameVariables.bummers;

            TotalPopsText.text = totalPops.ToString();
            LevelsText.text = myLevels.ToString();

            BummersText.text = GameVariables.bummers.ToString();

            PopsLastLevelText.text = popsLastLevel.ToString();

            popsRemainingText.text = popsRemaining.ToString();

            if (myLevels <= 1)
            {
                  ml = 1;
            }
            else
            {
                  ml = myLevels;
            }

            if (totalPops <= 1)
            {
                  tp = 1;
            }
            else
            {
                  tp = totalPops;
            }
            if (bummersLeft <= 1)
            {
                  bl = 1;
            }
            else
            {
                  bl = bummersLeft;
            }
            scoreCalculation = ml * tp * bl;
            FinalScoreText.text = scoreCalculation.ToString();


      }

}
