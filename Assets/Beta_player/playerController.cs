using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool isGrounded = true;
    private bool isAlive =true;
    private float highjumpvalue = 0.9f;


    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;
    private Vector3 zero_Velocity = Vector3.zero;
    //testing

    public audioMaster audio;

    float groundedTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //initialize
        rigibody = GetComponent<Rigidbody2D>();
        rigibody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rigibody.gravityScale = 3f;
        //jump time
        jump_counter = jumptime;

        GameManager.SetPlayer(this);
        if (GameManager.inPlay)
        {
            GameManager.SpawnPlayer();
            transform.position = GameManager.GetCheckpointPosition();
        }

    }

    private void FixedUpdate()
    {
        moveVertical = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;
        moveHorizontal = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;

        if (moveHorizontal != 0)
            audio.step(GetComponent<playerController>());

        movement = new Vector2(moveHorizontal, 0f);

        if (isAlive == true)
        {
            Jump();
        }

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
    }

    private void Update()
    {
        if (groundedTimer > 0)
            groundedTimer -= Time.deltaTime;


        if (groundedTimer <= 0)
        {
            RaycastHit2D ground1 = Physics2D.Raycast(transform.position - new Vector3(0.35f, 1.4f, 0), Vector3.down, 0.05f);
            RaycastHit2D ground2 = Physics2D.Raycast(transform.position - new Vector3(-0.37f, 1.4f, 0), Vector3.down, 0.05f);

            if (ground1.collider != null)
            {
                if (!ground1.collider.CompareTag("Checkpoint"))
                {
                    if (!isGrounded)
                        audio.playerLand();

                    isGrounded = true;
                    groundedTimer = 0.2f;
                }
            }

            if (ground2.collider != null)
            {
                if (!ground2.collider.CompareTag("Checkpoint"))
                {
                    if(!isGrounded)
                        audio.playerLand();

                    isGrounded = true;
                    groundedTimer = 0.2f;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Spikes")
        {
            die();
            Debug.Log("SPIKE DEATH");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "MushroomGas")
        {
            die();
            Debug.Log("PlayerKILLED, SHROOMS");
        }
    }
    private void Jump()
    {
        //jump
        //jump if isgrounded
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded && !is_jumping)
        {
            isGrounded = false;
            is_jumping = true;
            jump_counter = jumptime;
            rigibody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }
        // hold space #jump higher
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && is_jumping)
        {
            if (jump_counter > 0)
            {
                rigibody.AddForce(new Vector2(0f, jumpforce * highjumpvalue), ForceMode2D.Force);
                Debug.Log("!!!!!2");

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
      //  StartCoroutine(Respawn());
    }


   // private IEnumerator Respawn()
   // {
   //     yield return new WaitForSeconds(2f);
   //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   // }

    public bool isDead()
    {
        return isAlive;
    }
}
