using System;
using UnityEngine;

public class Ballon : MonoBehaviour
{
      public GameObject popSound;
      public GameObject dieSound;
      public GameObject ballonCountDisplay;
      public GameObject[] wayPoints;
      public GameObject[] wayPoints2;
      private int nextWayPointIndex = 0; // the next waypoint to visit
                                         //     public int colorNum = 1;
      public float colorNum;
      public float speed = 1;
      private Material m_Material;

      public GameObject Waves;
      private bool alreadyHit = false; 


      // private DisplayText referenceScript;

      // private int maxBalloons;


      int CompareObNames(GameObject x, GameObject y)
      {
            return x.name.CompareTo(y.name);
      }
      private void Start()
      {
            var random = UnityEngine.Random.Range(0, 2);
            if (random == 0)
            {
                  wayPoints = GameObject.FindGameObjectsWithTag("Waypoints");
                  Array.Sort(wayPoints, CompareObNames);
            }
            else
            {
                  wayPoints = GameObject.FindGameObjectsWithTag("Waypoints2");
                  Array.Sort(wayPoints, CompareObNames);
            }
            m_Material = GetComponent<Renderer>().material;
            //Get sound component
            popSound = GameObject.FindGameObjectWithTag("PopSound");
            dieSound = GameObject.FindGameObjectWithTag("DieSound");
            //Get ballonCountDisplay
            ballonCountDisplay = GameObject.FindGameObjectWithTag("BallonCountDisplay");
            //   referenceScript = ballonCountDisplay.GetComponent<DisplayText>();

            // maxBalloons = referenceScript.maxBalloons;


            Waves = GameObject.FindGameObjectWithTag("Waves");



            ColorBallons();

      }

      // Update is called once per frame
      void Update()
      {
            //     ColorBallons();
            MoveBallon();


      }

      private void ColorBallons()
      {




            //   if (colorNum > 5)
            //   {
            //       m_Material.color = Color.black;
            //   }

            m_Material.color = Color.black;

            if (colorNum > 4)
            {
                  m_Material.color = Color.red;
            }

            if (colorNum <= 4)
            {
                  m_Material.color = Color.yellow;
            }
            if (colorNum <= 3)
            {
                  m_Material.color = Color.green;
            }
            if (colorNum <= 2)
            {
                  m_Material.color = Color.blue;
            }
            if (colorNum <= 1)
            {
                  m_Material.color = Color.magenta;
            }
      }

      private void OnTriggerEnter(Collider other)
      {
            if ((other.CompareTag("Dart")) && !alreadyHit)
            {

                  alreadyHit = true;


                  Debug.Log("----------------------  hit balloon -----------" + this.name);
                  // health--;
                  ballonCountDisplay.GetComponent<DisplayText>().BallonPopIncrease();
                  popSound.GetComponent<PopSound>().PlayPop();


                  // referenceScript.checkMaxBalloons();
                  //  Score.totalPops++;

                  // if (health <= 0)
                  // {
                  Destroy(this.gameObject);

                  // }

            }
      }
      private void MoveBallon()
      {




            var lastWayPointIndex = wayPoints.Length - 1; // keep track of the last waypoint
            Vector3 lastWayPoint = wayPoints[lastWayPointIndex].transform.position + new Vector3(0, 2, 0);  // make lastWayPoint the position plus 2m above ground
            Vector3 nextWayPoint = wayPoints[nextWayPointIndex].transform.position + new Vector3(0, 2, 0);
            Vector3 direction = nextWayPoint - transform.position; // direction applied to the balloon
                                                                   //If enemy is more than 0.1 meters from the last waypoint
            if (Vector3.Distance(transform.position, lastWayPoint) > 0.1f)
            {
                  speed = Waves.GetComponent<Waves>().balloonSpeed;
                  // Keep moving towards the next waypoint
                  transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
            //increase index so if enemy reaches one waypoint
            if (Vector3.Distance(transform.position, nextWayPoint) < 0.5f && nextWayPointIndex < lastWayPointIndex)
            {
                  nextWayPointIndex++;
            }
            //Ballon at Finish
            if (nextWayPointIndex == lastWayPointIndex && Vector3.Distance(transform.position, lastWayPoint) < 0.5f)
            {

                  //  Debug.Log("++++++++++++++++ Ballon at Finish called");

                  dieSound.GetComponent<DieSound>().PlayDie();
                  // ballonCountDisplay.GetComponent<DisplayText>().LivesDecrease();
                  // Score.bummers++;
                  GameVariables.bummers++;

                  Destroy(this.gameObject);

            }


      }
}
