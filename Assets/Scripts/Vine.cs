using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    public float maxY;
    public float minY;
    public float move;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Change in vertical distance 
        Vector3 oldPos = transform.position;

        // Move the game object on the vertical axis
        if (oldPos.y + move > maxY || oldPos.y + move < minY)
        {
            move = -move;
        }
        oldPos.y = oldPos.y + move;

        transform.position = oldPos;

    }
}
