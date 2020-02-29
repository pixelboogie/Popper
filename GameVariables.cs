using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{

      public static bool musicOn = true;
      public static int bummers = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("++++++++++++++++GameVariables Update bummers: " + bummers);
    }
}
