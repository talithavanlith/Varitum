using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class InanimateObject : MonoBehaviour
{
    private static float GravityScale = 5f;
    public float effectTime = 5f; // seconds
    private static Vector2 DefaultGravity = new Vector2(0, -6.8f);
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

    private bool isFalling;

    void Start()
    {
        gravity = DefaultGravity;
        isFalling = true;

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        timer = Instantiate(Resources.Load("CircularTimer", typeof(CircularTimer))) as CircularTimer;
        timer.transform.parent = transform;
        timer.transform.localPosition = Vector3.zero;
    }

    void FixedUpdate()
    {
        timer.SetValue(gravityTimer / effectTime);
        if (gravityTimer > 0)
            gravityTimer -= Time.deltaTime;
        else
        {
            gravity = DefaultGravity;
            isFalling = true;
            gravityTimer = 0;
        }

        if (isFalling)
            rigidbody.gravityScale = GravityScale;
        else
        {
            rigidbody.gravityScale = 0;
            rigidbody.velocity = gravity * GravityScale;
        }
    }

    public void ApplyGravity(GravityDirection direction)
    {
        int axisIndex = (int)direction;
        if (gravityTimer <= 0)
        {
            gravityTimer = effectTime;
            isFalling = false;
        }

        if (direction == GravityDirection.DOWN)
        {
            gravityTimer = 0;
            isFalling = true;
        }

        gravity = GravityDirections[axisIndex];
    }

    public bool IsFalling()
    {
        return isFalling;
    }
}
