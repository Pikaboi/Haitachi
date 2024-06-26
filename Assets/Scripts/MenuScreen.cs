﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    GlobalController cont;

    public GameObject text;
    public GameObject quitter;

    private Vector2 mousePos = new Vector2(500.0f, 350.0f);
    private bool start = false;
    private bool quit = false;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cont.controller.Menu.Enable();
        cont.keys.Menu.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        cont.keys.Menu.Move.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        cont.keys.Menu.Move.canceled += ctx => mousePos = Vector2.zero;
        cont.keys.Menu.Closegame.performed += ctx => Application.Quit();

        cont.controller.Menu.Start.performed += ctx => start = true;
        cont.controller.Menu.Start.canceled += ctx => start = false;

        cont.controller.Menu.Quit.performed += ctx => quit = true;
        cont.controller.Menu.Quit.canceled += ctx => quit = false;

        transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        if(Vector3.Distance(transform.position, text.transform.position) <= 10.0f)
        {
            cont.keys.Menu.Hold.performed += ctx => start = true;
            cont.keys.Menu.Hold.canceled += ctx => start = false;
            text.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        } else
        {
            text.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

        if (Vector3.Distance(transform.position, quitter.transform.position) <= 10.0f)
        {
            cont.keys.Menu.Hold.performed += ctx => quit = true;
            cont.keys.Menu.Hold.canceled += ctx => quit = false;
            quitter.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
        else
        {
            quitter.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

        if (start == true)
        {
            SceneManager.LoadScene(1);
        }

        if(quit == true)
        {
            Application.Quit();
        }

    }
}
