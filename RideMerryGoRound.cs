using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideMerryGoRound : MonoBehaviour
{
  
  void OnTriggerStay(Collider other){
             if(other.gameObject.tag == "MerryGoRound"){
             transform.parent = other.transform;
          }
     }
 
 void OnTriggerExit(Collider other){
     if(other.gameObject.tag == "MerryGoRound"){
             transform.parent = null;
             
         }
     }    

}
