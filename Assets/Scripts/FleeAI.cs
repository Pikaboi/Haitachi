﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeAI : MonoBehaviour
{
    public float speed;
    private Transform target;
    public Rigidbody rb;

    public LeaderFollowingAI AIscript;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();
        AIscript = GetComponent<LeaderFollowingAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AIscript.getInfected())
        {

            float dist = Vector3.Distance(transform.position, target.position);
            Debug.Log("Distance to other: " + dist);
            if (dist < 4.0f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(transform.position - target.transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5.0f * Time.deltaTime);
                transform.position += transform.forward * 5.0f * Time.deltaTime;
            }
        }
    }
}
