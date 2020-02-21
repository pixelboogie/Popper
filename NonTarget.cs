using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonTarget : MonoBehaviour
{

      public GameObject friendlyPrefab; // which prefab we will be spawning
      public Transform friendlyLocation; // the location we will spawn the friendly

      private float timeLeft = 8.0f; // time to remain before spawning the friendly

      private bool friendlySpawned = false;

      // Start is called before the first frame update
      void Start()
      {
            // var friendly = Instantiate(friendlyPrefab, friendlyLocation.position, friendlyLocation.transform.rotation);
      }

      // Update is called once per frame
      void Update()
      {


            if (friendlySpawned == false)
            {
                  timeLeft -= Time.deltaTime;

                  if (timeLeft < 0)
                  {
                        var friendly = Instantiate(friendlyPrefab, friendlyLocation.position, friendlyLocation.transform.rotation);
                        friendlySpawned = true;

                  }
            }
      }
}
