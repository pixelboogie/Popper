using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrack : MonoBehaviour
{

      AudioSource m_AudioSource;
      //  public static bool musicOn = true;



      // Start is called before the first frame update
      void Start()
      {
            m_AudioSource = GetComponent<AudioSource>();
            if (GameVariables.musicOn)
            {
                  m_AudioSource.Play();
            }
      }

      // Update is called once per frame
      void Update()
      {

            if (OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                  //     if (OVRInput.GetDown(OVRInput.Button.Four)){
                  //     if (OVRInput.GetDown(OVRInput.Touch.Two)){
                  ToggleMusic();
            }
      }



      void ToggleMusic()
      {
            if (GameVariables.musicOn)
            {
                  //     Debug.Log("----------------- stop it");
                  GameVariables.musicOn = false;
                  m_AudioSource.Stop();
            }
            else
            {
                  //  Debug.Log("----------------- play it");
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
