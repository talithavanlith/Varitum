using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMaster : MonoBehaviour
{
    public  AudioSource audioSource;

    public AudioClip shot;
   // public AudioClip jump;
    public AudioClip walk;
    public AudioClip land;
    public AudioClip die;
    public AudioClip blood;

 
    public AudioClip[] clips;

    public  void fire()
    {
        
        audioSource.volume = 0.09f;
        audioSource.PlayOneShot(shot);


    }
    private void shots()
    {
        
    }


    float lastStepTime;
    public void step(playerController player)
    {
        if (player && player.isGrounded && player.isAlive)
        { 
            if (Time.timeSinceLevelLoad > lastStepTime + 0.3f)
            {
                lastStepTime = Time.timeSinceLevelLoad;

                audioSource.volume = 0.2f;
                audioSource.PlayOneShot(walk);
            }
        }
    }

    public void playerLand()
    {
        audioSource.volume = 0.25f;
        audioSource.PlayOneShot(land);
    }

    public void playdie()
    {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(die);
    }
    public void playblood()
    {
        audioSource.volume = 1f;
        audioSource.PlayOneShot(blood);
    }
}
