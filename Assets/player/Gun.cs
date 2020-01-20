using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject player;
    private Transform playertransform;
    private float fireCD;
    public Transform gravityArcPrefab;
    // Start is called before the first frame update
    void Start()
    {
         playertransform = player.transform;
    }
    
    private void FixedUpdate()
    {
        rotate_direction();

        //Vector3 player_location = Camera.main.WorldToScreenPoint(playertransform.position);
        Vector3 p2 = playertransform.position;
        //Debug.Log(p2);
        
        transform.position = p2 + new Vector3(0.6f,0.1f,0f);


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target = Input.mousePosition;
            fire(transform.position, target);
        }


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



    private void fire (Vector3 gunpoition, Vector3 target)
    {

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 shotEnd = mouseRay.origin + mouseRay.direction;

       
       

        Transform arc = Instantiate(gravityArcPrefab, transform);
        //arc.GetComponent<GravityArc>().SetShotStartAndDirection(gunpoition, (Vector3)target-gunpoition );
         arc.GetComponent<GravityArc>().SetShotStartAndDirection(transform.position, (Vector3)shotEnd - transform.position);



    }
}
