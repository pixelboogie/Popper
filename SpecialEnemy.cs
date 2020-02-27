using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : MonoBehaviour
{

      private int killCount = 10;
      public AudioSource source;
      public AudioClip clip;

      public float throttle = 10f;

      public int health = 20;

      private Material m_Material;

      private Vector3 endPosition = new Vector3(0, 20, -25);

      // Start is called before the first frame update
      void Start()
      {
            m_Material = GetComponent<Renderer>().material;
      }

      // Update is called once per frame
      void Update()
      {

            float dist = Vector3.Distance(endPosition, transform.position);
            //     if(transform.position != endPosition){
            transform.Translate(Vector3.forward * Time.deltaTime * throttle);
            //   transform.Translate(Vector3.forward * Time.deltaTime);
            // Debug.Log("____________________   dist: " + dist);
            // }
            if (dist > 80)
            {
                  Destroy(gameObject);
            }

            ColorBallons();

      }


      private void ColorBallons()
      {

            if (health == 20)
            {
                  m_Material.color = Color.black;
            }

            if (health == 17)
            {
                  m_Material.color = Color.gray;
            }

            if (health == 14)
            {
                  m_Material.color = Color.cyan;
            }

            if (health == 10)
            {
                  m_Material.color = Color.red;
            }
            else if (health == 7)
            {
                  m_Material.color = Color.blue;
            }
            else if (health == 3)
            {
                  m_Material.color = Color.green;
            }
      }

      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Dart"))
            {
                  health--;
                  Score.totalPops++;

                  if (health <= 0)
                  {
                        // Destroy(this.gameObject);
                        explode();
                  }

            }
      }

      private void explode()
      {

            source.PlayOneShot(clip);

            // Debug.Log("________________________Explode");
            Score.totalPops = Score.totalPops + killCount;
            this.transform.localScale = new Vector3(0, 0, 0);
            Destroy(gameObject, 1.5f);
      }
}
