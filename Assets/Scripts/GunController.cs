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

    void Update()
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

    public void SetGravityDirection(GravityDirection direction)
    {
        gravityDirection = direction;
    }

    private void Shoot()
    {
        // Transform click from screen into game coordinate system
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 clickPos = mouseRay.origin + mouseRay.direction;

        // Create shot object
        GravityShot shot = Instantiate(gravityShotPrefab);
        shot.gameObject.name = "Shot (" + gravityDirection + ")";
        shot.InitShot(clickPos - transform.position, gravityDirection);
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
