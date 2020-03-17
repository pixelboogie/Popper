using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckshot : MonoBehaviour
{

      private Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(0.3f, 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale += scaleChange;
    }


   private void OnTriggerEnter(Collider other)
      {
  
                        Destroy(this.gameObject);

            
      }



}
