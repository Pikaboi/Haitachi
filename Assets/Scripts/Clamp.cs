using System.Collections;
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
       
    }
}
