using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GravityArc1 : MonoBehaviour
{
    private Vector3 shotStart;
    private Vector3 shotDirection;
    private LineRenderer lineRenderer;
    private const float Speed = 40f;
    private const float TrailSpeed = 10f;

    private float timeAlive;
    private const float MaxLifetime = 1f;

    private Vector2 collisionPos;
    private bool collided;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive > MaxLifetime)
            Destroy(gameObject);

        lineRenderer.positionCount = 2;

        Vector3 shotStartPoint = shotStart + shotDirection * (timeAlive < 0.05f ? 0 : (timeAlive * TrailSpeed));
        Vector3 shotEndPoint = collided ? (Vector3)collisionPos : (shotStart + (shotDirection * timeAlive * Speed));

        lineRenderer.SetPositions(new Vector3[] { shotStartPoint, shotEndPoint });
        lineRenderer.endWidth = Mathf.Min((1f * timeAlive), 0.25f);
        lineRenderer.startWidth = 0.025f;


        RaycastHit2D hit = Physics2D.Raycast(shotStartPoint, shotDirection, Vector2.Distance(shotStartPoint, shotEndPoint));

        if (hit.collider && !hit.collider.gameObject.CompareTag("Player"))
        {
            collisionPos = hit.point;
            //    collided = true;
           // Debug.Log("HIT");
        }


    }


    public void SetShotStartAndDirection(Vector3 start, Vector3 direction)
    {
        this.shotStart = start;
        this.shotDirection = direction.normalized;
    }
}
