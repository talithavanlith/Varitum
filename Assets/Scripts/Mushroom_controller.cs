using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_controller : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem particle;
    public ParticleSystem blood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("CRUSHED");
        InanimateObject obj = collision.gameObject.GetComponent<InanimateObject>();
        //animator.SetTrigger("die");
        if (obj && obj.IsFalling())
        {
            animator.SetTrigger("die");
            particle.Stop();
            blood.Play();
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }
    }
}
