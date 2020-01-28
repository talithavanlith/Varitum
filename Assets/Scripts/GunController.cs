using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
    private GravityDirection m_gravityDirection;

    void Start()
    {

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
        m_gravityDirection = (GravityDirection)(((int)m_gravityDirection + direction + 4) % 4);
    }

    public void SetGravityDirection(GravityDirection direction)
    {
        m_gravityDirection = direction;
    }

    private void Shoot()
    {
        // Transform click from screen into game coordinate system
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 clickPos = mouseRay.origin + mouseRay.direction;

        // Create shot object
        GravityShot shot = new GameObject().AddComponent<GravityShot>();
        shot.gameObject.name = "Shot (" + m_gravityDirection + ")";
        shot.InitShot(transform.position, clickPos - transform.position, m_gravityDirection);
    }
}
