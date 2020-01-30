using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class InanimateObject : MonoBehaviour
{
    private static float GravityScale = 5f;
    private static float UnscaledGravityTimer = 5f; // seconds
    private static Vector2 DefaultGravity = new Vector2(0, -9.8f);
    private static Vector2[] GravityDirections =
    {
        new Vector2(0, 1),
        new Vector2(1, 0),
        DefaultGravity,
        new Vector2(-1, 0),
    };

    private Vector2 gravity;
    private float gravityTimer;

    private new Rigidbody2D rigidbody;
    private CircularTimer timer;

    void Start()
    {
        gravity = DefaultGravity;

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        timer = Instantiate(Resources.Load("CircularTimer", typeof(CircularTimer))) as CircularTimer;
        timer.transform.parent = transform;
        timer.transform.localPosition = Vector3.zero;
    }

    void FixedUpdate()
    {
        timer.SetValue(gravityTimer / (UnscaledGravityTimer / rigidbody.mass));
        if (gravityTimer > 0)
            gravityTimer -= Time.deltaTime;
        else
        {
            gravity = DefaultGravity * GravityScale;
            gravityTimer = 0;
        }

        rigidbody.velocity = gravity;
    }

    public void ApplyGravity(GravityDirection direction)
    {
        int axisIndex = (int)direction;
        if (gravityTimer <= 0)
        {
            gravityTimer = UnscaledGravityTimer / rigidbody.mass;
        }

        if (direction == GravityDirection.DOWN)
            gravityTimer = 0;

        gravity = GravityDirections[axisIndex] * GravityScale;
    }
}
