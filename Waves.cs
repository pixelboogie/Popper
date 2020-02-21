using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public float difficulty = 0.4f;
    public float difficultyIncreaseSpeed = 0.01f;
    public Transform startPosition;
    public GameObject ballonGreen;

    //Timer
    private float ballonTimer = 0f;
    private float nextBallon = 1f;

    //Ballon limiter
    public int ballonsPerWave = 5;
    private int ballonsCount = 1;
    //waves timer
    public float wavesTimer = 0f;
    public float nextWave = 20f;

    // Update is called once per frame
    void Update()
    {
      //Send Ballons
     if(ballonTimer < Time.time && wavesTimer < Time.time)
        {
            ballonsCount++;
            difficulty += difficultyIncreaseSpeed;
            ballonTimer = Time.time + nextBallon;
 
                var ballon =  Instantiate(ballonGreen, startPosition.position, ballonGreen.transform.rotation);
                ballon.GetComponent<Ballon>().health += (int)System.Math.Round(difficulty);
                ballon.GetComponent<Ballon>().speed += (int)System.Math.Round(difficulty);
        }
     //create waves
        if (ballonsCount % ballonsPerWave == 0 && wavesTimer < Time.time)
        {
            wavesTimer = nextWave + Time.time;
        }

    }
}
