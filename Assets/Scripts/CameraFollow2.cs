using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{

    private Transform playerTransform;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //we stroe the current cameras position in a  
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;

        temp.x += offset;
        temp.y = playerTransform.position.y;
        temp.y += offset; 


        transform.position = temp;
    }
}
