using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Checkpoint : MonoBehaviour
{
    public int checkpointNum;
    public AudioSource audioSource;
    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<playerController>() && collision.GetComponentInParent<playerController>().CompareTag("Player") && collision.GetComponentInParent<playerController>().isDead())
        {
            if (transform.position.x > GameManager.GetCheckpointPosition().x + 1f)
            {
                audioSource.Play();
                audioSource.volume = 0.15f;
            }
            GameManager.SetCheckpointPosition(collision.gameObject.transform.position, checkpointNum);
            Color fadedYellow = new Color(223 / 255f, 221 / 255f, 111 / 255f);
            gameObject.GetComponent<Renderer>().material.color = fadedYellow;
        }
    }
}
