using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpecialWeapon : MonoBehaviour
{
      public GameObject mySpecialWeapon; // which prefab we will be spawning
      public Transform spawnLocation1; // the location we will spawn the friendly

      public Transform spawnLocation2; // the location we will spawn the friendly

      public Transform spawnLocation3; // the location we will spawn the friendly

      private Transform[] spawnLocations;


      public float spawnDelay = 3.0f; // time to remain before spawning
      public float spawnInterval = 20.0f; // time to remain before spawning



      public bool weaponActive = false;
      private int thisSpawn;



      void Start()
      {
            spawnLocations = new Transform[3];
            spawnLocations[0] = spawnLocation1;
            spawnLocations[1] = spawnLocation2;
            spawnLocations[2] = spawnLocation3;
      }

 
      void Update()
      {
            if (!weaponActive)
            {
                  spawnDelay -= Time.deltaTime;
                  if (spawnDelay < 0)
                  {
                        thisSpawn = UnityEngine.Random.Range(0, 3);
                        var friendly = Instantiate(mySpecialWeapon, spawnLocations[thisSpawn].position, spawnLocations[thisSpawn].transform.rotation);
                        spawnDelay = spawnInterval;
                        weaponActive = true;
                  }
            }
      }
}












