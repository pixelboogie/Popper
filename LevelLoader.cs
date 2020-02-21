using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;


    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){

        // SceneManager.LoadScene("Scene1");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

IEnumerator LoadLevel(int levelIndex){
    transition.SetTrigger("Start");

    yield return new WaitForSeconds(transitionTime);

    SceneManager.LoadScene(levelIndex);

}


}
