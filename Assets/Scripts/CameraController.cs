using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    private float xOffset;

    public enum MovementDirection { LEFT, NONE, RIGHT };
    private MovementDirection movementDirection;

    private float movementCooldown;
    private bool spamMove;

    void Start()
    {
        movementDirection = MovementDirection.NONE;
        player = transform.parent;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x + xOffset, 0, -10);

        if (movementCooldown > 0)
        {
            movementCooldown -= Time.deltaTime;
            if (spamMove)
                return;
        }
        else
        {
            spamMove = false;
        }

        if (movementDirection == MovementDirection.RIGHT && xOffset < 3)
        {
            xOffset += Time.deltaTime * 4;
        }
        else if (movementDirection == MovementDirection.LEFT && xOffset > -3)
        {
            xOffset -= Time.deltaTime * 4;
        }
    }

    public void SetMovementDirection(MovementDirection direction)
    {
        if (direction == MovementDirection.NONE)
            return;

        if (direction != this.movementDirection)
        {
            if (movementCooldown > 0)
                spamMove = true;

            movementCooldown = 0.6f;

        }

        this.movementDirection = direction;
    }
}
