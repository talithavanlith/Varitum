using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    private float shotCooldown;
    public Transform gravityArcPrefab;

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
            arc.GetComponent<GravityArc>().SetShotStartAndDirection(transform.position, (Vector3)shotEnd - transform.position);
        }
    }
}
