﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Changeprompt : MonoBehaviour
{
    public Text changingText;

    public int promptNum = 0;
    int num = 0;


    //this is for new input
    //Access to class
    Keyboard keys;
    Xbox controller;
    //Use this to check the button is pressed
    bool interactSuccess = false;

    //For input system
    //Does it as long as its enabled
    void Awake()
    {
        //New instance of the input map
        keys = new Keyboard();
        controller = new Xbox();

        //WARNING: Might still activate if you hold the button
        //if so add keys.Game.Interact.performed += ctx => interactSuccess = false;

        //Started will make it do on the first press, we want to ignore holds.
        keys.Game.Interact.started += ctx => interactSuccess = true;
        //Canceled is when the button isnt being pressed.
        keys.Game.Interact.canceled += ctx => interactSuccess = false;
        //Same as above for controller mapping
        controller.Game.Interact.started += ctx => interactSuccess = true;
        controller.Game.Interact.canceled += ctx => interactSuccess = false;
    }

    void OnEnable()
    {
        controller.Game.Enable();
        keys.Game.Enable();
    }

    //These turn controls off when not in use
    void OnDisable()
    {
        controller.Game.Disable();
        keys.Game.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(interactSuccess
    }

    public void changeNum(int n)
    {
        num = n;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("ineract");
            changeNum(promptNum);

            switch (num)
            {

                case 1: //Task one Completed
                    changingText.text = "X to interact";
                    promptNum = 2;

                    break;
                case 2: //Task two started
                    changingText.text = "Y to hifive";

                    break;
                default:
                    break;
            }
        }

        //Debug.Log("we collided");
        //Allow the Z talk button to be active
        //Menu.setToTalk();
        //Find Who Made the message based on tag
        // Menu.GetDialouge(GetComponent<DialogueTrigger>().dialouge);
        //Menu.setTag(other.gameObject.tag);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            changingText.text = "";

            //Destroy(GetComponent<BoxCollider>());
            //GetComponent<Changeprompt>().enabled = false;
        }
    }
}
