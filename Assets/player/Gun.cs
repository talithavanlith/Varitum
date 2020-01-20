using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private bool faceright = true;
      
    public GameObject player;
    public GameObject arm;
    private Transform arm_t;
    private Transform player_t;
    private float fireCD;
    public Transform gravityArcPrefab;
    // Start is called before the first frame update
    void Start()
    {
         player_t = player.transform;
        arm_t = arm.transform;
      //  arm_rotate_direction_right();
    }
    
    private void Update()
    {

        //rotate_direction();
        //arm_rotate_direction_right();
        if (faceright)
        {
            arm_rotate_direction_right();
        }
        else
        {
            arm_rotate_direction_left();
        }
        Debug.Log(transform.right.x);

        filp();
        

        //test code
       // if (Input.GetMouseButtonDown(0))
       // {
       //     Vector3 target = Input.mousePosition;
      //      fire(transform.position, target);
       // }


    }
    private void filp()
    {
        

        if (arm_t.right.x < 0.2 && faceright==true)
        {
            faceright = false;

            player_t.localScale.x.Equals(-1f);

            player_t.localRotation = Quaternion.Euler(0, 180, 0);
           // arm_t.localRotation = Quaternion.Euler(0, 180, 0);
            
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            // arm_rotate_direction_left();
            
        }
        else if(faceright==false && arm_t.right.x > -0.2)
        {
            faceright = true;
            player_t.localRotation = Quaternion.Euler(0, 0, 0);
           // arm_t.localRotation = Quaternion.Euler(0, 0, 0);
            // player_t.localRotation = Quaternion.Euler(0, 0, 0);

        }
    }
    private void attach_player()
    {
        //Vector3 player_location = Camera.main.WorldToScreenPoint(playertransform.position);
        Vector3 p2 = arm_t.position;
        //Debug.Log(p2);

        transform.position = p2 + new Vector3(0.6f, 0.1f, 0f);

        //transform.RotateAround(p2,new Vector3(0,0,1),15);
    }
    private void arm_attach_player()
    {
        //Vector3 player_location = Camera.main.WorldToScreenPoint(playertransform.position);
        Vector3 p2 = player_t.position;
        //Debug.Log(p2);

        arm_t.position = p2 + new Vector3(0f, 0f, 0f);

        //transform.RotateAround(p2,new Vector3(0,0,1),15);
    }

    private void rotate_direction()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mouse - obj;
        direction.z = 0f;
        //Debug.Log(direction);

        transform.right = direction;
    }

    private void arm_rotate_direction_right()
    {
        Vector3 p2 = player_t.position;
        Vector3 mouse = Input.mousePosition;
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mouse - obj;
        direction.z = 0f;
        //Debug.Log(direction);
       // arm_t.RotateAround(p2,new Vector3(0,0,1),5);
        arm_t.right = direction;
    }
    private void arm_rotate_direction_left()
    {
        Vector3 p2 = player_t.position;
        Vector3 mouse = Input.mousePosition;
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mouse - obj;
        direction.z = 0f;
        //Debug.Log(direction);
        // arm_t.RotateAround(p2,new Vector3(0,0,1),5);
        arm_t.right = -direction;
    }

    private void fire (Vector3 gunpoition, Vector3 target)
    {

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 shotEnd = mouseRay.origin + mouseRay.direction;
        
       

        Transform arc = Instantiate(gravityArcPrefab, transform);
        //arc.GetComponent<GravityArc>().SetShotStartAndDirection(gunpoition, (Vector3)target-gunpoition );

        //arc.GetComponent<GravityArc>().SetShotStartAndDirection(transform.position, (Vector3)shotEnd - transform.position);



    }
}
