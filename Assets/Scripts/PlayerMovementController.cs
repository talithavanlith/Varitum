using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovementController : MonoBehaviour
{
    public float jumpHeight = 8;
    private new Rigidbody2D rigidbody;
    private bool grounded = false;

    public CameraController camera;

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
        float horizontalMovement = Input.GetAxis("Horizontal");
        camera.SetMovementDirection(horizontalMovement > 0 ? CameraController.MovementDirection.RIGHT : horizontalMovement < 0 ? CameraController.MovementDirection.LEFT : CameraController.MovementDirection.NONE);


        //Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector2 mousePos = mouseRay.origin + mouseRay.direction;
        //if (mousePos.x > transform.position.x)
        //    camera.SetMovementDirection(CameraController.MovementDirection.RIGHT);
        //else
        //    camera.SetMovementDirection(CameraController.MovementDirection.LEFT);

        transform.position = transform.position + new Vector3(Time.deltaTime * horizontalMovement * 6, 0);

        if (Input.GetButton("Jump") && grounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
        }
    }
}
