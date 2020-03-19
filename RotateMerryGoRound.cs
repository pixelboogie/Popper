using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMerryGoRound : MonoBehaviour
{

      public int roateSpeed = 10;



    // Update is called once per frame
    void Update()
    {
      //   transform.Rotate(new Vector3(Time.deltaTime*200,0,0));
      //   transform.Rotate(Vector3.right * Time.deltaTime);
      //   transform.Rotate(Time.deltaTime, 0, 0);
      transform.Rotate(0, roateSpeed * Time.deltaTime, 0);
    }
}
