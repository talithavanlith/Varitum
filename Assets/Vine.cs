using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    SpriteRenderer renderer;

    public float speed = 10f;
    public float minY = 3f, maxY = 12f, startY = 3f;
    private float oldY;

    void Start()
    {
        oldY = maxY;
        renderer = GetComponent<SpriteRenderer>();
        renderer.size = new Vector2(renderer.size.x, startY);
    }

    void FixedUpdate()
    {
        Vector3 oldSize = renderer.size;

        // Move the game object on the vertical axis
        if (oldSize.y + (speed * Time.deltaTime) > maxY || oldSize.y + (speed * Time.deltaTime) < minY)
        {
            speed *= -1;
        }

        oldSize.y = oldSize.y + (speed * Time.deltaTime);


        renderer.size = oldSize;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        InanimateObject obj = collision.gameObject.GetComponent<InanimateObject>();
        if (obj)
        {
            maxY = transform.localScale.x;
            //renderer.size = renderer.size - new Vector2(0, 0.5f);
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
            maxY = oldY;
    }
}
