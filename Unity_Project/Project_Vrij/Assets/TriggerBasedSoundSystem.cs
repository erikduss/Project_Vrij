using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBasedSoundSystem : MonoBehaviour
{
    public AudioSource narrativeAudio;
    public AudioClip audioToPlay;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            narrativeAudio.clip = audioToPlay;
            narrativeAudio.Play();
        }
    }

}
