using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class InanimateObject : MonoBehaviour
{
    private static float GravityScale = 5f;
    private static float UnscaledGravityTimer = 5f; // seconds
    private static Vector2 DefaultGravity = new Vector2(0, -9.8f);
    private static Vector2[] GravityDirections =
    {
        new Vector2(0, 1),
        DefaultGravity,
        new Vector2(-1, 0),
        new Vector2(1, 0)
    };


    private Vector2 gravity;
    private float gravityTimer;

    private new Rigidbody2D rigidbody;

    void Start()
    {
        gravity = DefaultGravity;

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (gravityTimer > 0)
            gravityTimer -= Time.deltaTime;
        else
            gravity = DefaultGravity * GravityScale;

        rigidbody.velocity = gravity;
    }

    public void ApplyGravity(GravityDirection direction)
    {
        int axisIndex = (int)direction;
        gravityTimer = UnscaledGravityTimer / rigidbody.mass;
        gravity = GravityDirections[axisIndex] * GravityScale;
    }
}
