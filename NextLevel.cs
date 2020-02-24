using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class NextLevel : MonoBehaviour
{

      public float transitionTime = 2f;
      private int levelIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
                  transitionTime -= Time.deltaTime;
                  if (transitionTime < 0) {
                  
                  loadNextLevel();
                  }
    }

    
    public void loadNextLevel(){

        // SceneManager.LoadScene("Scene1");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      // StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

       levelIndex = SceneManager.GetActiveScene ().buildIndex + 1;
            SceneManager.LoadScene (levelIndex);
    }





}
