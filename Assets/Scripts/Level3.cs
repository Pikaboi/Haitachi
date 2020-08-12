using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public ExtendCam counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter.getCount() == 6)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in objs)
            {
                enemy.GetComponent<FleeAI>().speed = 6;
            }
        }
    }
}
