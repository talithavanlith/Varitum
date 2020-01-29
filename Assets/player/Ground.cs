using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
      //  player= gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag=="Ground")
        {
            //##########################################
            //change gun to player controller sprite
            player.GetComponent<gun>().isGrounded= true;

            Debug.Log("grounded");
        }
    }
    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            //##########################################
            //change gun to player controller sprite
            player.GetComponent<gun>().isGrounded = false;
            Debug.Log("grounded-false");
        }
    }
}
