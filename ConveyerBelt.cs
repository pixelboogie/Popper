using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{


public GameObject belt;
public Transform endpoint;
public float speed;

private void Update() {
            // Debug.Log("_______________________________Update");
}


void OnTriggerStay(Collider other){
//  private void OnCollisionStay(Collision other) {


      // Debug.Log("_______________________________TRIGGER");
      other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
}

}
