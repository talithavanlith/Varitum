using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        //Camera.main.WorldToScreenPoint( Input.mousePosition)

        arm_rotate_direction_right();
        Debug.DrawLine(arm_t.position, Camera.main.WorldToScreenPoint(transform.position), Color.red);
        Debug.DrawLine(arm_t.position, Camera.main.ScreenToWorldPoint( Input.mousePosition), Color.green);
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(Input.mousePosition, 1f);
    }*/
    private void arm_rotate_direction_right()
    {
        Vector3 p2 = player_t.position;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 obj = Camera.main.WorldToScreenPoint(arm_t.position);
        Vector3 direction = mouse - arm_t.position;
        direction.z = 0f;
        //Debug.Log(direction);
        // arm_t.RotateAround(p2,new Vector3(0,0,1),5);
        arm_t.right = direction;
    }


}
