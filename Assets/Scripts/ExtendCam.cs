using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendCam : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    private float infectedCount = 0;
    void Start()
    {
       cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addInfected()
    {
        infectedCount++;

        if (infectedCount == 6)
        {
            Debug.Log("active");
            cam.orthographicSize += 30;
        }
    }
}
