using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    Camera cam;
    Vector3 screenPos;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        screenPos = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        Debug.Log("target is " + screenPos.x + " pixels from the left" + screenPos.y);

        transform.position = screenPos;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 view = transform.position;

        //view.x = Mathf.Clamp(view.x, screenPos.x, screenPos.x);


        /*if(transform.position.x > (cam.fieldOfView / 4))
        {
            transform.position = new Vector3((cam.fieldOfView / 4), transform.position.y, transform.position.z);
        }

        if(transform.position.x < -(cam.fieldOfView / 4))
        {
            transform.position = new Vector3(-(cam.fieldOfView / 4), transform.position.y, transform.position.z);
        }

        if (transform.position.z > (cam.fieldOfView / 4))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (cam.fieldOfView / 4));
        }

        if (transform.position.z < -(cam.fieldOfView / 4))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -(cam.fieldOfView / 4));
        }*/
    }
}
