using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public float difficulty = 0.4f; // used in 2 formulas: speed and health(color)
    public float difficultyIncreaseSpeed = 0.01f; // how much is added each update to difficulty
    public Transform startPosition;
    public GameObject ballonGreen;

    //Timer
    private float ballonTimer = 0f; // so they can spawn every frame???
    private float nextBallon = 1f; // amt of time to wait before spawning next???

    //Ballon limiter
    public int ballonsPerWave = 10;  // how many to spawn per wave???

      public int waveIncreaser = 20;  // how more to spawn each wave
    private int ballonsCount = 1; // number of balloons spawned
    //waves timer
    public float wavesTimer = 0f; // set to nextWave + currenttime
    public float nextWave = 20f; // amount of time to wait before the next wave

    // Update is called once per frame
    void Update()
    {
      //Send Ballons
     if(ballonTimer < Time.time && wavesTimer < Time.time)
        {
            ballonsCount++;
            difficulty += difficultyIncreaseSpeed;
            if(difficulty > 5){
                  difficulty = 5;
            }



            ballonTimer = Time.time + nextBallon;
 
                var ballon =  Instantiate(ballonGreen, startPosition.position, ballonGreen.transform.rotation);
                ballon.GetComponent<Ballon>().health += (int)System.Math.Round(difficulty);
                ballon.GetComponent<Ballon>().speed += (int)System.Math.Round(difficulty);
        }
     //create waves
        if (ballonsCount % ballonsPerWave == 0 && wavesTimer < Time.time)
        {
              ballonsPerWave += waveIncreaser;
            wavesTimer = nextWave + Time.time;
        }

    }
}
