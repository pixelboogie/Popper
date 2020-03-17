using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : MonoBehaviour
{

      private int killCount = 0;
      public AudioSource source;
      public AudioClip clip;

      public float throttle = 5f;

      public int health = 10;

      private Material m_Material;

      // public Vector3 endPosition = new Vector3(0, 20, 25);
 


      private bool alreadyExploded = false;

      // ------------------------------------
      public GameObject myAnimatorObject;
      Animator myAnimator;

      private bool resetAnim = false;
      private float waitTime = 30.0f;



      void Start()
      {
            m_Material = GetComponent<Renderer>().material;

               myAnimator = GetComponent<Animator>();
      }
      void Update()
      {

            // float dist = Vector3.Distance(endPosition, transform.position);
            //     if(transform.position != endPosition){
            transform.Translate(Vector3.right * Time.deltaTime * throttle);
            //   transform.Translate(Vector3.forward * Time.deltaTime);
            // Debug.Log("____________________   dist: " + dist);
            // }
            // if (dist > 80)
            // {
            //       Destroy(gameObject);
            // }

                  waitTime -= Time.deltaTime;

                  if (waitTime < 0)
                  {
                        //    Debug.Log("------------------------ waitTime ");
                        Destroy(gameObject);

                  }

      }
      

      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Dart"))
            {
                  health--;
                  // Score.totalPops++;
                  // DisplayText.ballonPopCount++;

                  Destroy(other.gameObject); // destroy the arrow

                  if (health <= 0)
                  {
                        // Destroy(this.gameObject);
                        explode();
                  }

            }
      }

      private void explode()
      {

            // Debug.Log("++++++++++++++++ explode called");
            
            if (!alreadyExploded)
            {
                              // Debug.Log("++++++++++++++++ explode if statement called");
                  
                  alreadyExploded = true;
                  source.PlayOneShot(clip);

                  if (Score.bummersLeft < 10)
                  {
                        GameVariables.bummers--;
                  }
 

                  playDie();
                        
            }
      }


            public void playDie()
      {
            // Debug.Log("------------------------ playDie ");
            myAnimator.SetBool("AnimeDie", true);
            // waitTime = .3f;
            // resetAnim = true;
      }



public void destoryIt(){
      //     Debug.Log("------------------------ destoryIt ");
      //     myAnimator.SetBool("AnimeDie", false);
       Destroy(gameObject);
}
}
