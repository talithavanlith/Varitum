using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    public float maxX = 1.4f;
    public float minX = 0.1f;
    public float move = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
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

        transform.localScale = oldPos;

    }
}
