using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSound : MonoBehaviour
{
      public AudioSource source;
      public AudioClip die;




      public void PlayDie()
      {
            source.PlayOneShot(die);
      }
}
