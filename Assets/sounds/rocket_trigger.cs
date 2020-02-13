using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket_trigger : MonoBehaviour
{
   public rocket_audio rocket_Audio;
    public PolygonCollider2D PolygonCollider2D;
    
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.CompareTag("Player"))
        {
            rocket_Audio.close();
            PolygonCollider2D.enabled = false;
            collision.gameObject.SetActive(false);

            GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject o in objs)
                o.SetActive(false);
        }
    }
}
