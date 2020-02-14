using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    private Animator animator;
    public AudioSource AudioSource;
    public float offset;
    void Start()
    {
        animator = GetComponent<Animator>();
        // float randomIdleStart = Random.Range(0, animator.GetCurrentAnimatorStateInfo(1).length); //Set a random part of the animation to start from
        animator.SetFloat("speed",offset);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        InanimateObject obj = collision.gameObject.GetComponent<InanimateObject>();
        if (obj)
        {
            animator.SetBool("attact", false);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.die();
        }
    }

    private void Update()
    {
        AudioSource.mute = !GameManager.soundEnabled;
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
