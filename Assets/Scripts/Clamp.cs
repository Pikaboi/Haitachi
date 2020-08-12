﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    Camera cam;
    Vector3 screenPos;

    float height;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        height = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 view = transform.position;
        height = cam.orthographicSize;

        //view.z = Mathf.Clamp(view.z, height, -height);

        if (view.z < -height)
        {
            view.z = -height;
        }

        if (view.z > height)
        {
            view.z = height;
        }

        if (view.x < -height)
        {
            view.x = -height;
        }

        if (view.x > height)
        {
            view.x = height;
        }

        transform.position = view;

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