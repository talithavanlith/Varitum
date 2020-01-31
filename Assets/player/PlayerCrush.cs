using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrush : MonoBehaviour
{

    public playerController player;

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
        if (obj && obj.IsFalling())
        {
            player.die();
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }
    }

   
}
