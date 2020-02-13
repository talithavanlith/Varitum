using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralaxing : MonoBehaviour
{

    public Transform[] backgrounds; // Array of all back and foregrounds to be parllaxed
    private float[] parallaxScales;   //The proportion of the cameras movement to move the backgrounds by
    public float smoothing = 1f;         //How smooth the parallax is going to be. Make sure to set this above 0.

    public Transform cam;      //reference to the main camera transform
    private Vector3 previousCamPos; //the position of the camera in the previous frame

    //Called before Start(). Great for references.
    void Awake()
    {
        // set up the camera reference
        //cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //The previous frame had the current frame's camera position
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];
        for(int i = 0; i<backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
       //for each background
       for(int i =0; i<backgrounds.Length; i++)
        {
            //The parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            //set a target exposition which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //create a target position which is the backgrounds current position with its target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade between cureent position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

        //set the previous cam position to the cameras position at the end of the frame
        previousCamPos = cam.position;
    }
}
