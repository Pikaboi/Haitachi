using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6 : MonoBehaviour
{
    GameObject[] objs;
    float timer = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("Follower");
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;

        if (timer == 0)
        {
            timer = 3.0f;
            Destroy(objs[0]);
        }
    }
}
