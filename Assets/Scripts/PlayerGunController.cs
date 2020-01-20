using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    private float shotCooldown;
    public Transform gravityArcPrefab;

    public enum GunDirection { UP, DOWN, LEFT, RIGHT };
    private GunDirection gunDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shotCooldown > 0)
            shotCooldown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && shotCooldown <= 0)
        {
            shotCooldown = 0.5f;

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 shotEnd = mouseRay.origin + mouseRay.direction;

            Transform arc = Instantiate(gravityArcPrefab, transform);
            arc.GetComponent<GravityArc>().SetShotStartAndDirection(transform.position, (Vector3)shotEnd - transform.position, gunDirection);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetGunDirection(GunDirection.UP);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetGunDirection(GunDirection.RIGHT);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetGunDirection(GunDirection.DOWN);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SetGunDirection(GunDirection.LEFT);
    }

    public void SetGunDirection(GunDirection direction)
    {
        gunDirection = direction;
    }
}
