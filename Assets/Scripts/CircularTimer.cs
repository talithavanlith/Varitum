using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularTimer : MonoBehaviour
{
    private Renderer renderer;
    private float value;
    

    void Start()
    {
        renderer = GetComponent<Renderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.SetFloat("_Angle", value * 360);
    }

    internal void SetValue(float newValue)
    {
        this.value = newValue;
    }
}
