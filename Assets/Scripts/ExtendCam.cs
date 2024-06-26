﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtendCam : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    public float infectedGoal = 0;
    private float infectedCount = 0;

    AudioSource music;

    void Start()
    {
       cam = Camera.main;
       infectedCount = 0;

        music = gameObject.GetComponent<AudioSource>();

        music.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addInfected()
    {
        infectedCount++;

        if(infectedCount == infectedGoal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public float getCount()
    {
        return infectedCount;
    }
}
