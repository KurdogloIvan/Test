using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource swordAudio;
    public AudioSource hammerAudio;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SwordTrigger")
        {
            swordAudio.Play();
        }
        else
        {
            hammerAudio.Play();
        }
    }

}
