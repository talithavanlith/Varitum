using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip closedoor;
    public AudioClip rocket_lauch;
    public Animator Animator;
    public BoxCollider2D BoxCollider2D;
    public PolygonCollider2D PolygonCollider2D;
   
    public void launch()
    {
        Animator.SetTrigger("launch");
        audioSource.PlayOneShot(rocket_lauch);
    }
    public void close()
    {
        Animator.SetTrigger("close");
        audioSource.PlayOneShot(closedoor);
    }
   
   


}
