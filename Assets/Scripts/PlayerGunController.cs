using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    private float shotCooldown;
    public Transform gravityShotPrefab;

    //set defult
     private static GravityDirection gunDirection=GravityDirection.DOWN;


    public Texture arrowImage;
    public Texture dialImage;

    private Vector2 selectPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shotCooldown > 0)
            shotCooldown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(1))
        {
            selectPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else if (Input.GetMouseButton(1))
        {
            Vector2 selectDirection = (Vector2)Input.mousePosition - selectPos;


            if (Mathf.Abs(selectDirection.x) > Mathf.Abs(selectDirection.y))
            {
                if (selectDirection.x > 0)
                {
                    gunDirection = GravityDirection.RIGHT;
                }
                else if (selectDirection.x < 0)
                {
                    gunDirection = GravityDirection.LEFT;
                }
            }
            else
            {
                if (selectDirection.y > 0)
                {
                    gunDirection = GravityDirection.UP;
                }
                else if (selectDirection.y < 0)
                {
                    gunDirection = GravityDirection.DOWN;
                }
            }
            
        }
        else if (Input.GetMouseButtonDown(0) && shotCooldown <= 0)
        {
            shotCooldown = 0.5f;

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 shotEnd = mouseRay.origin + mouseRay.direction;

            Transform shot = Instantiate(gravityShotPrefab, transform);
            shot.GetComponent<GravityShot>().SetShotStartAndDirection(transform.position, (Vector3)shotEnd - transform.position, gunDirection);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        int direction = scroll > 0 ? -1 : scroll < 0 ? 1 : 0;

        gunDirection = (GravityDirection) (((int)gunDirection + direction + 4) % 4);

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetGunDirection(GravityDirection.UP);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetGunDirection(GravityDirection.RIGHT);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetGunDirection(GravityDirection.DOWN);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SetGunDirection(GravityDirection.LEFT);
    }

    public static void SetGunDirection(GravityDirection direction)
    {
        gunDirection = direction;
    }


    private void OnGUI()
    {
        if (arrowImage != null && dialImage != null)
        {
            // Hud showing current status
            GUIUtility.RotateAroundPivot((int)gunDirection * 90, new Vector2(50, 50));
            GUI.DrawTexture(new Rect(0, 0, 100, 100), arrowImage, ScaleMode.ScaleToFit);
            GUIUtility.RotateAroundPivot((int)gunDirection * -90, new Vector2(50, 50));



            if (Input.GetMouseButton(1))
            {
                GUI.DrawTexture(new Rect(selectPos.x - 50, Screen.height - selectPos.y - 50, 100, 100), dialImage, ScaleMode.ScaleToFit);

                Vector2 pivotPoint = new Vector2(selectPos.x, Screen.height - selectPos.y);

                GUIUtility.RotateAroundPivot((int) gunDirection * 90, pivotPoint);
                GUI.DrawTexture(new Rect(selectPos.x - 50, Screen.height - selectPos.y - 50, 100, 100), arrowImage, ScaleMode.ScaleToFit);
                GUIUtility.RotateAroundPivot((int)gunDirection * -90, new Vector2(0, Screen.height) - selectPos);
            }
        }
    }
}
