using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position.x > 50.0f)
        {
            transform.position = new Vector3(50.0f, transform.position.y, transform.position.z);
        }

        if(transform.position.x < -50.0f)
        {
            transform.position = new Vector3(-50.0f, transform.position.y, transform.position.z);
        }
    }
}
