using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckshot : MonoBehaviour
{


       public Vector3 startPosition;
      private float dist; 
      private Vector3 scaleChange;



    void Start()
    {

          startPosition =  transform.position;
      //   scaleChange = new Vector3(0.3f, 0.3f, 0.3f);
        scaleChange = new Vector3(1.7f, 1.7f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

       dist = Vector3.Distance(startPosition, transform.position);

       if(dist < 32){
        this.transform.localScale += scaleChange;
        } else {
                 Destroy(this.gameObject);          
        }
    }


   private void OnTriggerEnter(Collider other)
      {
            Destroy(this.gameObject);          
      }



}
