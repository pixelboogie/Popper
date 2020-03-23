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

      private bool alreadyExploded = false;

      public GameObject myAnimatorObject;
      Animator myAnimator;

      private bool resetAnim = false;
      private float waitTime = 45.0f;



      void Start()
      {
            m_Material = GetComponent<Renderer>().material;
            myAnimator = GetComponent<Animator>();
      }
      void Update()
      {
            transform.Translate(Vector3.right * Time.deltaTime * throttle);
            waitTime -= Time.deltaTime;
            if (waitTime < 0)
            {
                  Destroy(gameObject);
            }
      }


      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Dart"))
            {
                  health--;
                  Destroy(other.gameObject); // destroy the arrow

                  if (health <= 0)
                  {
                        explode();
                  }

            }
      }

      private void explode()
      {

            if (!alreadyExploded)
            {
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
            myAnimator.SetBool("AnimeDie", true);

      }



      public void destoryIt()
      {
            Destroy(gameObject);
      }
}
