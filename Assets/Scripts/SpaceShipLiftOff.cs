using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipLiftOff : MonoBehaviour
{
    private GameObject spaceShip;
    private Vector3 coordinates;
    private GameObject[] flames;
    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag("SpaceShip");
        flames = GameObject.FindGameObjectsWithTag("shipFlame");
        coordinates = spaceShip.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        coordinates = spaceShip.transform.position;
        spaceShip.transform.SetPositionAndRotation(new Vector3(coordinates.x, coordinates.y + 1, coordinates.z), spaceShip.transform.rotation);
        for(int i= 0; i<flames.Length; i++)
        {
            Debug.Log("wtf");
            flames[i].transform.SetPositionAndRotation(new Vector3(flames[i].transform.position.x, coordinates.y-19, flames[i].transform.position.z-4), spaceShip.transform.rotation);
        }
    }
}
