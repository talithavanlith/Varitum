using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
   
    public void launch()
    {
        audioSource.Play();
    }
}
