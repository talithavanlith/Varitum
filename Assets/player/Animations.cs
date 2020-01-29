using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
   
    //public 
    public GameObject player;
    public GameObject arm;
    public GameObject mainbody;
    //local data fields
    private bool faceright = true;
    private Transform arm_t;
    private Transform player_t;
    private float fireCD;
    private Animator anim;
   // public Transform gravityArcPrefab;



    // Start is called before the first frame update
    void Start()
    {
        player_t = player.transform;
        arm_t = arm.transform;
        anim = mainbody.GetComponent<Animator>();
        //  arm_rotate_direction_right();

    }

    // Update is called once per frame
    void Update()
    {
        //Camera.main.WorldToScreenPoint( Input.mousePosition)

        arm_rotate_direction_right();
        Debug.DrawLine(arm_t.position, Camera.main.WorldToScreenPoint(transform.position), Color.red);
        Debug.DrawLine(arm_t.position, Camera.main.ScreenToWorldPoint( Input.mousePosition), Color.green);
        //play animation

      float  moveHorizontal = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;

        if (moveHorizontal != 0)
        {
            anim.SetBool("isRunning",true);
            Debug.Log("running");
        }
        else
        {
            anim.SetBool("isRunning", false);
        }


    }
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(Input.mousePosition, 1f);
    }*/
    private void arm_rotate_direction_right()
    {
        //Vector3 p2 = player_t.position;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       // Vector3 obj = Camera.main.WorldToScreenPoint(arm_t.position);
        Vector3 direction = mouse - arm_t.position;
        direction.z = 0f;
        //Debug.Log(direction);
        // arm_t.RotateAround(p2,new Vector3(0,0,1),5);
        arm_t.right = direction;
    }


}
