using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Score : MonoBehaviour
{

      public static int myScore = 0;
      public TextMeshPro ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //   if(myScore>0){
      //         Debug.Log("myScore is: " + myScore);
      //   }

      ScoreText.text = myScore.ToString();
    }




}
