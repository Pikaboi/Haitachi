using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionText : MonoBehaviour
{
    //The Script that controls the menu
    private DialogueActivated Menu;

    //this is for new input
    Keyboard keys;
    Xbox controller;
    bool interactSuccess = false;

    //For input system
    void Awake()
    {
        keys = new Keyboard();
        controller = new Xbox();

        keys.Game.Move.started += ctx => interactSuccess = true;
        keys.Game.Move.canceled += ctx => interactSuccess = false;
        controller.Game.Move.started += ctx => interactSuccess = true;
        controller.Game.Move.canceled += ctx => interactSuccess = false;
    }

    //These turn the controls off when not in use.
    void OnEnable()
    {
        controller.Game.Enable();
        keys.Game.Enable();
    }

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
    }
    void Update()
    {
        
        //testing  the event activates it shall go through the talk event
        if (interactSuccess)
        {
            Menu.setToTalk();
            //Find Who Made the message based on tag
            Menu.GetDialouge(GetComponent<DialogueTrigger>().dialouge);
        }
        //if (Input.GetKeyDown(KeyCode.Space)
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("we collided");
        //Allow the Z talk button to be active
        Menu.setToTalk();
        //Find Who Made the message based on tag
        Menu.GetDialouge(GetComponent<DialogueTrigger>().dialouge);
        //Menu.setTag(other.gameObject.tag);
    }

    void OnTriggerExit(Collider other)
    {
        //Turn off the talk button
        Menu.stopTalk();
    }
}
