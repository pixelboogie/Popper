using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
      public GameObject specialEnemy; // which prefab we will be spawning
      public Transform enemyLocation; // the location we will spawn the friendly
      public float spawnDelay = 8.0f; // time to remain before spawning
      public float spawnInterval = 30.0f; // time to remain before spawning

      // private bool enemySpawned = false;
      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {
            // if (enemySpawned == false)
            {
                  spawnDelay -= Time.deltaTime;

                  if (spawnDelay < 0)
                  {
                        var friendly = Instantiate(specialEnemy, enemyLocation.position, enemyLocation.transform.rotation);
                        // enemySpawned = true;
                        spawnDelay = spawnInterval;
                  }
            }

      }
}
