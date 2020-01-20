using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
       // fireCD += Time.fixedDeltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target = Input.mousePosition;

        }


    }


    private void fire (Vector3 gunpoition, Vector3 target)
    {




    }
}
