using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    public ExtendCam counter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        if (counter.getCount() == 1)
        {
            foreach (GameObject enemy in objs)
            {
                enemy.GetComponent<FleeAI>().speed = 6;
            }
        }
    }
}
