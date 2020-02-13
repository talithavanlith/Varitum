using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocket_audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip closedoor;
    public AudioClip rocket_lauch;
    public Animator Animator;
    public BoxCollider2D BoxCollider2D;
    public PolygonCollider2D PolygonCollider2D;

    private bool leaving, gameEnded;

    public void launch()
    {
        Animator.SetTrigger("launch");
        audioSource.PlayOneShot(rocket_lauch);
    }
    public void close()
    {
        Animator.SetTrigger("close");
        audioSource.PlayOneShot(closedoor);
        Destroy(Camera.main.GetComponent<CameraController>());
        Camera.main.transform.parent = transform;
        leaving = true;
    }

    private void Update()
    {
        if (leaving && !gameEnded)
        {
            if (Camera.main.transform.localPosition.x < 3)
                Camera.main.transform.localPosition = Camera.main.transform.localPosition + new Vector3(Time.deltaTime * 1.5f, 0);
            if (Camera.main.orthographicSize > 7f)
                Camera.main.orthographicSize -= Time.deltaTime / 2f;

            SpriteRenderer bg = Camera.main.GetComponentInChildren<SpriteRenderer>();

            if (transform.localPosition.y > 46f)
            {
                bg.transform.localPosition = new Vector3(bg.transform.localPosition.x, bg.transform.localPosition.y, 5);
            }

            if (transform.localPosition.y > 145f)
            {
                Camera.main.transform.parent = transform.parent;
                gameEnded = true;
            }
        }

        if (gameEnded)
        {
            if (transform.localPosition.y > 205f)
            {
                SpriteRenderer bg = Camera.main.GetComponentInChildren<SpriteRenderer>();
                bg.material.color = bg.material.color - Time.deltaTime * new Color(1, 1, 1, 0);
            }

            if (transform.localPosition.y > 230f)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
