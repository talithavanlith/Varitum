using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    [SerializeField] private LayerMask layermask;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log("grounded-false");
        //  player= gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
            player.GetComponent<playerController>().isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<playerController>().isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //player.GetComponent<gun>().isGrounded=colld


       /* if (collision.collider.tag=="Ground")
        {
            //##########################################
            //change gun to player controller sprite
            player.GetComponent<gun>().isGrounded= true;

            Debug.Log("grounded");
        }*/
    }
    private void OnCollisionExit2D (Collision2D collision)
    {
       /* if (collision.collider.tag == "Ground")
        {
            //##########################################
            //change gun to player controller sprite
            player.GetComponent<gun>().isGrounded = false;
            Debug.Log("grounded-false");
        }*/
    }
}
