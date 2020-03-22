using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
//     public float WaveColor = 1.0f; // used in 2 formulas: speed and health(color)
//     public float difficultyIncreaseSpeed = 0.01f; // how much is added each update to difficulty
    public Transform startPosition;
    public GameObject ballonGreen;

    //Timer
    private float ballonTimer = 0f; // so they can spawn every frame???
    private float nextBallon = 1.2f; // amt of time to wait before spawning next???

    //Ballon limiter
    public int ballonsPerWave = 10;  // how many to spawn per wave???

      public int waveIncreaser = 20;  // how more to spawn each wave
    private int ballonsCount = 0; // number of balloons spawned
    //waves timer
    public float wavesTimer = 10f; // set to nextWave + currenttime
    public float nextWave = 30f; // amount of time to wait before the next wave


      public float balloonSpeed = 1.0f;

      public float speedIncreaser = 0.2f;


      private float colorFactor;

      private GameObject referenceObject;
      private DisplayText referenceScript;

//     private bool doneYet = false;

    private int maxBalloons;

    // Update is called once per frame


void Start(){

               referenceObject = GameObject.FindWithTag("BallonCountDisplay");
            referenceScript = referenceObject.GetComponent<DisplayText>();

      maxBalloons = referenceScript.maxBalloons;

      colorFactor = maxBalloons/5;

}



    void Update()
    {


      //     if(!doneYet){
      //Send Ballons
     if(ballonTimer < Time.time && wavesTimer < Time.time)
        {

              // change flag so we don't spawn more balloons
            ballonsCount++;
            // if(ballonsCount > maxBalloons){
            //       doneYet = true;
            // }


            // WaveColor += difficultyIncreaseSpeed;
            // if(WaveColor > 5){
            //       WaveColor = 5;
            // }



            ballonTimer = Time.time + nextBallon;
 
                var ballon =  Instantiate(ballonGreen, startPosition.position, ballonGreen.transform.rotation);
            //     ballon.GetComponent<Ballon>().colorNum += (int)System.Math.Round(WaveColor);
                ballon.GetComponent<Ballon>().colorNum = ballonsCount/colorFactor;
                  // ballon.GetComponent<Ballon>().colorNum = WaveColor;
            //     ballon.GetComponent<Ballon>().speed += (int)System.Math.Round(difficulty);


              
                
        }
     //create waves
        if (ballonsCount % ballonsPerWave == 0 && wavesTimer < Time.time)
            //    if (ballonsCount % ballonsPerWave == 0)
        {
            //     balloonSpeed +=  (int)System.Math.Round(difficulty);
                 balloonSpeed += speedIncreaser;
                 if(balloonSpeed > 10){
                       balloonSpeed =10;
                 }
                  // WaveColor ++;
                  // WaveColor  += speedIncreaser;

              ballonsPerWave += waveIncreaser;
            wavesTimer = nextWave + Time.time;
        }

    }
//     }
}
