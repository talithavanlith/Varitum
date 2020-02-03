using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionFollow : MonoBehaviour
{

    private GameObject player = GameObject.FindWithTag("Player");
    private GameObject companion = GameObject.FindWithTag("Companion");
    private Vector3 location;

    // Start is called before the first frame update
    void Start()
    {
        location = player.transform.position;
        companion.transform.SetPositionAndRotation(new Vector3(location.x+1, location.y+1, location.z), player.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        location = player.transform.position;
        companion.transform.Translate(new Vector3(location.x + 1, location.y + 1, location.z));
    }
}
