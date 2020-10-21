using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskText : MonoBehaviour
{
    //The Script that controls the menu
    private TaskActivated Menu;

    //this is for new input
    //Access to class
    Keyboard keys;
    Xbox controller;
    //Use this to check the button is pressed
    bool interactSuccess = false;

    bool OnlyOnce = true;
    
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

    //These turn the controls on when in use.
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

    void Start()
    {
        //Menu.setToTalk();
        //Find Who Made the message based on tag
        //Menu.GetDialouge(GetComponent<DialogueTrigger>().dialouge);
        GameObject MenuObj = GameObject.FindGameObjectWithTag("taskManager");
        Menu = MenuObj.GetComponent<TaskActivated>();
    }
    void Update()
    {
        /*
        //testing  the event activates it shall go through the talk event
        if (interactSuccess && OnlyOnce)
        {

            Debug.Log("Talk to once");
            Menu.setToTalk();
            //Find Who Made the message based on tag
            Menu.GetDialouge(GetComponent<DialogueTrigger>().dialouge);
            OnlyOnce = false;
        }
        */
        //if (Input.GetKeyDown(KeyCode.Space)
    }
    public void GiveTask()
    {
        if (OnlyOnce)
        {
            Debug.Log("Talk to once");
            Menu.setToTalk();
            //Find Who Made the message based on tag
            Menu.GetDialouge(GetComponent<DialogueTrigger>().dialouge);
            OnlyOnce = false;
        }
        
    } 
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("we collided");
        //Allow the Z talk button to be active
        //Menu.setToTalk();
        //Find Who Made the message based on tag
        //Menu.GetDialouge(GetComponent<DialogueTrigger>().dialouge);
        //Menu.setTag(other.gameObject.tag);
    }

    void OnTriggerExit(Collider other)
    {
        //Turn off the talk button
        Menu.stopTalk();
    }
}
