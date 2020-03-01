using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpecialWeapon : MonoBehaviour
{
      public GameObject mySpecialWeapon; // which prefab we will be spawning
      public Transform spawnLocation; // the location we will spawn the friendly
      public float spawnDelay = 3.0f; // time to remain before spawning
      public float spawnInterval = 20.0f; // time to remain before spawning

      // private bool enemySpawned = false;
      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

            spawnDelay -= Time.deltaTime;


            // if we have less than 10 bummers
            // if (Score.bummersLeft < 10)
            // {
                  if (spawnDelay < 0)
                  {
                        var friendly = Instantiate(mySpecialWeapon, spawnLocation.position, spawnLocation.transform.rotation);
                        // GameVariables.bummers--;
                        spawnDelay = spawnInterval;
                  }
            // }

      }
}
