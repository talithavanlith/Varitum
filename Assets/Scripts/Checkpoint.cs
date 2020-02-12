using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Checkpoint : MonoBehaviour
{
    public int checkpointNum;

    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<playerController>() && collision.GetComponentInParent<playerController>().CompareTag("Player"))
        {
            GameManager.SetCheckpointPosition(collision.gameObject.transform.position, checkpointNum);
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
