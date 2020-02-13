using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    private Animator animator;
    public AudioSource AudioSource;
    void Start()
    {
        animator = GetComponent<Animator>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        InanimateObject obj = collision.gameObject.GetComponent<InanimateObject>();
        if (obj)
        {
            Debug.Log("AAAA");
            animator.SetBool("attact", false);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.die();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        InanimateObject obj = collision.gameObject.GetComponent<InanimateObject>();
        if (obj)
        {
            animator.SetBool("attact", true);
        }
    }
    public void attack()
    {
        AudioSource.Play();
    }
}
