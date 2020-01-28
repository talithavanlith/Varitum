using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    //data fields
    private Rigidbody2D rigibody;
    //get player's input
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 movement;
    public float speed = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        //initialize
        rigibody = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        moveVertical = Input.GetKey(KeyCode.W)?1:Input.GetKey(KeyCode.S)?-1:0;
        moveHorizontal= Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
        movement = new Vector2(moveHorizontal,0f);

    }
    private void FixedUpdate()
    {
        if (rigibody.velocity.x<0 && rigibody.velocity.x>-6)
        {
            rigibody.AddForce(movement*20f*speed);
        }else if (rigibody.velocity.x < 6 && rigibody.velocity.x > 0)
        {
            rigibody.AddForce(movement * 20f * speed);
        }


        rigibody.AddForce(movement*10F*speed);
    }
}
