using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{

      private float radius = 20f;
      private float force = 4000f;

      private int killCount = 0;


      public AudioSource source;
      public AudioClip clip;


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
                        if(nearbyObject.CompareTag("Balloon")){
                                killCount++;
                        }

                  Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

                  if (rb != null){
                        rb.AddExplosionForce(force, transform.position, radius);
                        Destroy(rb.gameObject, .5f);
                  }
                 
            }

              Score.totalPops = Score.totalPops + killCount; 
            DisplayText.popsThisLevel =  DisplayText.popsThisLevel + killCount;
              this.transform.localScale = new Vector3(0,0,0);
            Destroy(gameObject, 2.5f);
      }

}
