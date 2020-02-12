using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMaster : MonoBehaviour
{
    public  AudioSource audioSource;

     public AudioClip shot;
    public AudioClip jump;
    public AudioClip walk;
    public AudioClip land;
    

 
    public AudioClip[] clips;

    public  void fire()
    {
        audioSource.PlayOneShot(shot);


    }
    private void shots()
    {
        
    }
    public void step()
    {
        if (playerController.isplayerGrounded() == true)
        {
            audioSource.volume = 0.1f;
            audioSource.PlayOneShot(walk);
        }
    }
}
