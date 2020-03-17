using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                         Score.totalPops = 0; 
                  Score.myLevels = 0; 
                  GameVariables.bummers = 0;
    }


}
