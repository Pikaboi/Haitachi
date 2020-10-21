using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionText : MonoBehaviour
{
    //The Script that controls the menu
    private DialogueActivated Menu;
    public TaskText taskScript;
    private TaskText tasktransfer;
    //this is for new input
    //Access to class
    Keyboard keys;
    Xbox controller;
    //Use this to check the button is pressed
    bool interactSuccess = false;

    bool OnlyOnce = true;
    bool Isinteractable = false;
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
        GameObject MenuObj = GameObject.FindGameObjectWithTag("dialougeManager");
        Menu = MenuObj.GetComponent<DialogueActivated>();

        if(taskScript != null)
        {
            tasktransfer = taskScript;
        }
    }
    void Update()
    {
        
        //testing  the event activates it shall go through the talk event
        if (interactSuccess && OnlyOnce)
        {
            if (Isinteractable)
            {
                //Debug.Log("Talk to once");
                Menu.setToTalk();
                //Find Who Made the message based on tag
                Menu.GetDialouge(GetComponent<DialogueTrigger>().dialouge);
                Menu.setTag(gameObject.tag);
                OnlyOnce = false;
                Isinteractable = false;
                Menu.SetTheTask(tasktransfer);
            }
        }
        //if (Input.GetKeyDown(KeyCode.Space)
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Isinteractable = true;
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
            //Turn off the talk button
            Menu.stopTalk();
            OnlyOnce = true;
            Isinteractable = false;
        }
    }
}
