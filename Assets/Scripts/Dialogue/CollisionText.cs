using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionText : MonoBehaviour
{
    //The Script that controls the menu
    private DialogueActivated Menu;


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
        if (Input.GetKeyDown(KeyCode.X))
        {
            Menu.setToTalk();
            //Find Who Made the message based on tag
            Menu.GetDialouge(GetComponent<DialogueTrigger>().dialouge);
        }
        //if (Input.GetKeyDown(KeyCode.Space)
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("we collided");
        //Allow the Z talk button to be active
        Menu.setToTalk();
        //Find Who Made the message based on tag
        Menu.GetDialouge(GetComponent<DialogueTrigger>().dialouge);
        //Menu.setTag(other.gameObject.tag);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Turn off the talk button
        Menu.stopTalk();
    }
}
