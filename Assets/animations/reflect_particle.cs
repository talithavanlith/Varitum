using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflect_particle : MonoBehaviour
{
    public ParticleSystem reflect;

    public void Play()
    {
        reflect.Play();
        StartCoroutine(stop());
    }

    private IEnumerator stop()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
