using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    public float maxX = 1.4f;
    public float minX = 0.1f;
    
    public float move = 0.02f;

    private float oldX;
    private int stop = 1;

    // Start is called before the first frame update
    void Start()
    {
        oldX = maxX;
    }

    // Update is called once per frame
    void Update()
    {
        // Change in vertical distance 
        Vector3 oldPos = transform.localScale;

        // Move the game object on the vertical axis
        if (oldPos.x + move > maxX || oldPos.x + move < minX)
        {
            move = -move;
        }
        oldPos.x = oldPos.x + move;
        //oldPos.x = oldPos.x + move * stop;

        transform.localScale = oldPos;

        //stop = 1; 
    }

    // On collision with a trigger collider...
    void OnTriggerEnter2D(Collider2D other)
    {

        //If that refernce is not null, then check if it's an enemyProjectile      
        if (other.tag == "Player")
        {

            //    // Destroy the projectile game object
            //    Destroy(other.gameObject);

        }
        else
        {
            //stop = 0;
            maxX = transform.localScale.x;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //If that refernce is not null, then check if it's an enemyProjectile      
        if (other.tag == "Player")
        {

            //    // Destroy the projectile game object
           //Destroy(other.gameObject);

        }
        else
        {
            //stop = 1;
            maxX = oldX;
        }
    }

}
