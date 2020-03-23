using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrack : MonoBehaviour
{

      AudioSource m_AudioSource;
  
      void Start()
      {
            m_AudioSource = GetComponent<AudioSource>();
            if (GameVariables.musicOn)
            {
                  m_AudioSource.Play();
            }
      }


      void Update()
      {

            if (OVRInput.GetDown(OVRInput.RawButton.Y))
            {
          
                  ToggleMusic();
            }
      }



      void ToggleMusic()
      {
            if (GameVariables.musicOn)
            {
                 
                  GameVariables.musicOn = false;
                  m_AudioSource.Stop();
            }
            else
            {
              
                  GameVariables.musicOn = true;
                  m_AudioSource.Play();
            }
      }


      public void PauseMusic()
      {
            m_AudioSource.Stop();
      }

      public void UnPauseMusic()
      {
            m_AudioSource.Play();
      }
}
