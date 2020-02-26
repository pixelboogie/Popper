using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{

      public float radius = 200f;
      public float force = 700f;

      private int killCount = 0;


      public AudioSource source;
      public AudioClip clip;

      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }

      private void OnTriggerEnter(Collider other)
      {

            if (other.CompareTag("Dart"))
            {

                  explode();
            }
      }


      private void explode()
      {
      killCount = 0;

           Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            // GameObject[] myObjects = Physics.OverlapSphere(transform.position, radius);

            source.PlayOneShot(clip);


            foreach (Collider nearbyObject in colliders)
            {
                  killCount++;
                  //  Destroy(nearbyObject, .5f);
                  Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                  if (rb != null){
                        rb.AddExplosionForce(force, transform.position, radius);
                        Destroy(rb.gameObject, .5f);
                  }
                 
            }


            // Debug.Log("________________________Explode");
              Score.myScore =   Score.myScore + killCount;
              this.transform.localScale = new Vector3(0,0,0);
            Destroy(gameObject, 2.5f);
      }

}
