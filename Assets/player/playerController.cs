using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //data fields
    private Rigidbody2D rigibody;
    //get player's input
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 movement;
    private float jump_counter;
    private bool is_jumping=false;
    
    //value
    private float acceleration = 1.2f;
    private float maxspeed = 10f;
    private float jumpforce = 9.8f;
    private float jumptime=0.4f;
    public bool isGrounded = false;
    private bool isAlive =true;
    private float highjumpvalue = 0.9f;

    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;
    private Vector3 zero_Velocity = Vector3.zero;
    //testing


    // Start is called before the first frame update
    void Start()
    {
        //initialize
        rigibody = GetComponent<Rigidbody2D>();
        rigibody.collisionDetectionMode=CollisionDetectionMode2D.Continuous;
        rigibody.gravityScale = 3f;
        //jump time
        jump_counter = jumptime; 
    }

    // Update is called once per frame
    void Update()
    {
        moveVertical = Input.GetKey(KeyCode.W)?1:Input.GetKey(KeyCode.S)?-1:0;
        moveHorizontal= Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
        movement = new Vector2(moveHorizontal,0f);
        
        if (isAlive == true)
        {
            Jump();
        }
       
    }
    private void FixedUpdate()
    {
     

        //horizontal move
        Vector3 targetVelocity = new Vector2(moveHorizontal*maxspeed,rigibody.velocity.y);
        if (isAlive == true)
            rigibody.velocity = Vector3.SmoothDamp(rigibody.velocity,targetVelocity,ref zero_Velocity,MovementSmoothing);


        //Debug.Log("player velocity"+rigibody.velocity);
        //horizontal move
        /* if (rigibody.velocity.x<0 && rigibody.velocity.x>-6)
         {
             rigibody.AddForce(movement*20f*acceleration);
         }else if (rigibody.velocity.x < 6 && rigibody.velocity.x > 0)
         {
             rigibody.AddForce(movement * 20f * acceleration);
         }*/



        //  rigibody.AddForce(movement*10F*speed);
    }
    private void Jump()
    {
        //jump
        //jump if isgrounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            is_jumping = true;
            jump_counter = jumptime;
            rigibody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }
        //hold space #jump higher
        if (Input.GetKey(KeyCode.Space) && is_jumping)
        {
            if (jump_counter > 0)
            {
                rigibody.AddForce(new Vector2(0f, jumpforce * highjumpvalue), ForceMode2D.Force);
                jump_counter -= Time.deltaTime;
            }
            else
            {
                is_jumping = false;
            }

        }
        //relase sapce
        if (Input.GetKeyUp(KeyCode.Space))
        {
            is_jumping = false;
        }

    }
    public void die()
    {
        isAlive = false;

    }
    public bool isDead()
    {
        return isAlive;
    }
}
