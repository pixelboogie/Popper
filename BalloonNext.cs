﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BalloonNext : MonoBehaviour
{

      public GameObject popSound;
      private int levelIndex;



      public GameObject myAnimatorObject;
      Animator myAnimator;

      private bool alreadyFaded = false; // have we faded in yet
      private float waitTime = 1f; // time to wait before fading in


      // Start is called before the first frame update
      void Start()
      {
            myAnimator = myAnimatorObject.GetComponent<Animator>();
      }

      // Update is called once per frame
      void Update()
      {

            if (!alreadyFaded)
            {
                  waitTime -= Time.deltaTime;
                  if (waitTime <= 0)
                  {
                        fadeIn();
                  }
            }
      }

      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Dart"))
            {
                  popSound.GetComponent<PopSound>().PlayPop();
                  //     Destroy(this.gameObject);
                  this.transform.localScale = new Vector3(0, 0, 0);
                  myAnimator.SetTrigger("playIntersceneFadeIn");
                  // levelIndex = SceneManager.GetActiveScene ().buildIndex + 1;
                  // SceneManager.LoadScene (levelIndex);


            }
      }




      public void goNextLevel()
      {
            Debug.Log("++++++++++++++++ goNextLevel called");
            levelIndex = SceneManager.GetActiveScene().buildIndex + 1;

            SceneManager.LoadScene(levelIndex);
      }


      private void fadeIn()
      {
            alreadyFaded = true;
            myAnimator.SetTrigger("playIntersceneFadeOut");  // when we start, fade out the sphere
      }


}
