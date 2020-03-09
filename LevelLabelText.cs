using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelLabelText : MonoBehaviour
{
          private int thisLevelNum;


      public TextMeshPro levelText;

    void Start()
    {
        thisLevelNum = SceneManager.GetActiveScene ().buildIndex/2;
        levelText.text = "Level " + thisLevelNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
