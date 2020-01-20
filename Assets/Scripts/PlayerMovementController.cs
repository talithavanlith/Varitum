using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovementController : MonoBehaviour
{
    public float jumpHeight = 8;
    private new Rigidbody2D rigidbody;
    private bool grounded = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        RaycastHit2D[] hits;

        //We raycast down 1 pixel from this position to check for a collider
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

        //if a collider was hit, we are grounded
        if (hits.Length > 0)
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }


    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(Time.deltaTime * Input.GetAxis("Horizontal") * 6, 0);

        if (Input.GetButton("Jump") && grounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
        }
    }
}
