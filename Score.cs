using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Score : MonoBehaviour
{

      public static int totalPops = 0;
      public static int popsLastLevel = 0;
      public static int myLevels = 0;

      private int bummersAllowed = 10;
      // public static int bummers = 0;
      public static int bummersLeft;


      public TextMeshPro TotalPopsText;

      public TextMeshPro LevelsText;

      public TextMeshPro FinalScoreText;

      public TextMeshPro BummersText;

      public TextMeshPro PopsLastLevelText;

      private int ml = 1; // minimum for score calc
      private int tp = 1; // minimum for score calc
      private int bl = 1; // minimum for score calc


      // Start is called before the first frame update
      void Start()
      {
      //   bummersLeft = bummersAllowed;
             bummersLeft = bummersAllowed - GameVariables.bummers;
            //  Debug.Log("--------------------------- Start bummersLeft   " + bummersLeft);
      }

      // Update is called once per frame
      void Update()
      {
 
             bummersLeft = bummersAllowed - GameVariables.bummers;

            //  Debug.Log("-------------------------Score-Update -bummersLeft   " + bummersLeft);
                  // Debug.Log("----------------------Score----Update   GameVariables.bummers " + GameVariables.bummers);

            TotalPopsText.text = totalPops.ToString();
            LevelsText.text = myLevels.ToString();

            BummersText.text = GameVariables.bummers.ToString();
            // BummersText.text = bummersLeft.ToString();
            PopsLastLevelText.text = popsLastLevel.ToString();

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

            int scoreCalculation = ml * tp * bl;
            FinalScoreText.text = scoreCalculation.ToString();


      }




}
