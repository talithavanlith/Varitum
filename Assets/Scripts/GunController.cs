using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
    private GravityDirection gravityDirection;
    public GravityShot gravityShotPrefab;

    private Texture gunWheelTexture;
    private Texture gunWheelOnTexture;

    void Start()
    {
        gunWheelTexture = Resources.Load<Texture>("gun_wheel");
        gunWheelOnTexture = Resources.Load<Texture>("gun_wheel_on");
    }

    void FixedUpdate()
    {
        // Left click to shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        // Scroll to change gravity direction
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        int direction = scroll > 0 ? -1 : scroll < 0 ? 1 : 0;
        gravityDirection = (GravityDirection)(((int)gravityDirection + direction + 4) % 4);
    }



    void OnDrawGizmos()
    {
        //Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector2 mousePos = mouseRay.origin + mouseRay.direction;
        //Vector2 shoulderPos = transform.parent.parent.parent.position;

        //float distance = Vector2.Distance(mousePos, shoulderPos);
        //float radius = 2f;

        //if (distance < radius)
        //{
        //    Vector2 fromShoulderToMouse = mousePos - shoulderPos;
        //    Gizmos.DrawRay(shoulderPos, fromShoulderToMouse);
            
        //    Gizmos.color = Color.blue;
        //    Gizmos.DrawSphere(shoulderPos + (fromShoulderToMouse.normalized * radius), 0.2f);
        //}

        //Gizmos.color = Color.green;
        //Gizmos.DrawSphere(mousePos, 0.1f);

    }

    public void SetGravityDirection(GravityDirection direction)
    {
        gravityDirection = direction;
    }

    private void Shoot()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 mousePos = mouseRay.origin + mouseRay.direction;
        Vector2 shoulderPos = transform.parent.parent.parent.position;

        float distance = Vector2.Distance(mousePos, shoulderPos);
        float radius = 2f;

        if (distance < radius)
        {
            Vector2 fromShoulderToMouse = mousePos - shoulderPos;
            mousePos = shoulderPos + (fromShoulderToMouse.normalized * radius);
        }


        // Create shot object
        GravityShot shot = Instantiate(gravityShotPrefab);
        shot.gameObject.name = "Shot (" + gravityDirection + ")";
        shot.InitShot((Vector3)mousePos - transform.position, gravityDirection);
        shot.transform.position = transform.position;
    }

    private void OnGUI()
    {
        // Hud showing current status
        GUI.DrawTexture(new Rect(20, 20, 100, 100), gunWheelTexture, ScaleMode.ScaleToFit);

        GUIUtility.RotateAroundPivot((int)gravityDirection * 90, new Vector2(70, 70));
        GUI.DrawTexture(new Rect(20, 20, 100, 100), gunWheelOnTexture, ScaleMode.ScaleToFit);
    }
}
