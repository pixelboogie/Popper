
using UnityEngine;

public class PopSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip pop;


   public void PlayPop()
    {
        source.PlayOneShot(pop);
    }
}
