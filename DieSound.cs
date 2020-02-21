using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSound : MonoBehaviour
{
      public AudioSource source;
      public AudioClip die;

      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }




      public void PlayDie()
      {
            source.PlayOneShot(die);
      }
}
