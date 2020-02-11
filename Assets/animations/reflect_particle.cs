using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflect_particle : MonoBehaviour
{
     public ParticleSystem reflect;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        //reflect.playOnAwake = false;
       // reflect.enableEmission = false;
       // reflect.Stop();
    }
    public void play()
    {
        if (!reflect.isPlaying)
        {
            reflect.Play();
            Debug.Log("reflect play()");
        }
        else
        {

            reflect.Stop();
            play();

        }
       
        
    }
    // Update is called once per frame
    void Update()
    {
        //reflect.Play();
    }
}
