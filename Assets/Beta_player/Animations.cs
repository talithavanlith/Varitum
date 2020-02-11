using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    //public
    public Vector3 dis=new Vector3(2,2,0);
    public GameObject player;
    public GameObject arm;
    //public GameObject forearm;
    public GameObject mainbody;
    public Transform bodyRoot;
    public ParticleSystem blood;


    //local data fields
    private bool faceright = true;
    private Transform arm_t;
    private Transform forearm_t;
    private Transform player_t;
    private float fireCD;
    private Animator anim;
    private Vector3 player_localscale;
    private bool drop = true;
    // public Transform gravityArcPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player_t = player.transform;
        arm_t = arm.transform;
        //forearm_t = forearm.transform;
        anim = mainbody.GetComponent<Animator>();
        //  arm_rotate_direction_right();

        //blood.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        //Camera.main.WorldToScreenPoint( Input.mousePosition)


        // Debug.DrawLine(GameObject.FindGameObjectWithTag("Test").transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red); 

        // Debug.DrawLine(arm_t.position, Camera.main.ScreenToWorldPoint( Input.mousePosition), Color.green);
        // Debug.DrawLine(arm_t.position, Input.mousePosition, Color.green);
         Debug.DrawLine(arm_t.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.yellow);

        //Debug.Log("mouse postion: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //Debug.Log(arm_t.position+ "  :  "+ Input.mousePosition);
        //play animation



        //check if die

        if (player.GetComponent<playerController>().isDead() == true)
        {
            //flip
            flip();
            //check if is running 
            isRunning(Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0);
        }
        else
        {
            blood.Play();

            anim.SetTrigger("die");

            if (drop)
            {
                arm_t.localPosition -= new Vector3(0, 2f, 0);
                drop = false;
                arm.SetActive(false);

            }

        }




    }

    private void flip()
    {

        if (arm_t.position.x >= Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            arm_rotate_direction_right();
            if (faceright != true)
            {
                player_localscale = bodyRoot.transform.localScale;
                player_localscale.x = 1f;
                faceright = true;
                bodyRoot.localScale = player_localscale;


                bodyRoot.localPosition += new Vector3(3.8f, 0f, 0f);
            }
        }
        else
        {
            arm_rotate_direction_left();
            if (faceright == true)
            {
                player_localscale = bodyRoot.transform.localScale;
                player_localscale.x = -1f;
                faceright = false;
                bodyRoot.localScale = player_localscale;
                bodyRoot.localPosition -= new Vector3(3.8f, 0f, 0f);
            }
        }
    }


    private void isRunning(float moveHorizontal)
    {
        if (moveHorizontal != 0)
        {
            anim.SetBool("running", true);
            //  Debug.Log("running");
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    private void arm_rotate_direction_right()
    {
        //Vector3 p2 = player_t.position;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       // Vector3 obj = Camera.main.WorldToScreenPoint(arm_t.position);
        Vector3 direction = mouse - arm_t.position;
        direction.z = 0f;
        //Debug.Log(direction);
        // arm_t.RotateAround(p2,new Vector3(0,0,1),5);
       // direction.y= Mathf.Clamp(direction.y, -45, 45);
       // forearm_t.right = direction;
        arm_t.up = -direction;
    }
    private void arm_rotate_direction_left()
    {
        //Vector3 p2 = player_t.position;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Vector3 obj = Camera.main.WorldToScreenPoint(arm_t.position);
        Vector3 direction = mouse - arm_t.position;
        direction.z = 0f;
        //Debug.Log(direction);
        // arm_t.RotateAround(p2,new Vector3(0,0,1),5);
        
        arm_t.up = -direction;
    }

}
