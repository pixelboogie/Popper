using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BalloonNext : MonoBehaviour
{

       public GameObject popSound; 
      private int levelIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dart"))
        {


              popSound.GetComponent<PopSound>().PlayPop();

            //     Destroy(this.gameObject);
  this.transform.localScale = new Vector3(0, 0, 0);  

            levelIndex = SceneManager.GetActiveScene ().buildIndex + 1;
            SceneManager.LoadScene (levelIndex);

           
        }
    }
}
