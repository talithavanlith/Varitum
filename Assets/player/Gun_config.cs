using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_config : MonoBehaviour
{
    public GameObject wheelU;
    public GameObject wheelD;
    public GameObject wheelR;
    public GameObject wheelL;
    public Sprite wheel1;
    public Sprite wheel2;
    private SpriteRenderer spr;

    private GravityDirection current = GravityDirection.DOWN;
    // Start is called before the first frame update
    void Start()
    {
        spr = wheelR.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousewheel();



    }
    private void mousewheel()
    {
        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            all_drak();
            if (current == GravityDirection.DOWN)
            {
                current = GravityDirection.LEFT;
                spr = wheelL.GetComponent<SpriteRenderer>();
                spr.sprite = wheel2;
                // PlayerGunController.SetGunDirection(GravityDirection.LEFT);

            } else if (current == GravityDirection.LEFT)
            {
                current = GravityDirection.UP;
                spr = wheelU.GetComponent<SpriteRenderer>();
                spr.sprite = wheel2;
            }
            else if (current == GravityDirection.UP)
            {
                current = GravityDirection.RIGHT;
                spr = wheelR.GetComponent<SpriteRenderer>();
                spr.sprite = wheel2;
            }
            else if (current == GravityDirection.RIGHT)
            {
                current = GravityDirection.DOWN;
                spr = wheelD.GetComponent<SpriteRenderer>();
                spr.sprite = wheel2;
            }
            PlayerGunController.SetGunDirection(current);


        }
        else
        {

        }

    }

    private void test()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerGunController.SetGunDirection(GravityDirection.RIGHT);
            Debug.Log("p-right");
            spr = wheelL.GetComponent<SpriteRenderer>();
            spr.sprite = wheel1;
            spr = wheelR.GetComponent<SpriteRenderer>();
            spr.sprite = wheel2;

        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerGunController.SetGunDirection(GravityDirection.LEFT);
            Debug.Log("p-left");

            spr = wheelR.GetComponent<SpriteRenderer>();
            spr.sprite = wheel1;
            spr = wheelL.GetComponent<SpriteRenderer>();
            spr.sprite = wheel2;


        }
    }
    private void all_drak() {
        spr = wheelR.GetComponent<SpriteRenderer>();
        spr.sprite = wheel1;
        spr = wheelL.GetComponent<SpriteRenderer>();
        spr.sprite = wheel1;
        spr = wheelU.GetComponent<SpriteRenderer>();
        spr.sprite = wheel1;
        spr = wheelD.GetComponent<SpriteRenderer>();
        spr.sprite = wheel1;

    }

}
