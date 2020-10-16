using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueActivated : MonoBehaviour
{
    GameObject[] DialougeBoxes;
    GameObject[] MenuBoxes;
    private bool CanTalk;
    private string Intertag;
    private bool isTalk;

    Dialogue CurrentSpeech;

    public Text nameText;
    public Text dialogueText;

    public Queue<string> sentences;

    //this is for new input
    Keyboard keys;
    Xbox controller;
    bool interactSuccess = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        // Unpauses game if paused
        Time.timeScale = 1;

        DialougeBoxes = GameObject.FindGameObjectsWithTag("DialogueUI");
        hideDialouge();

        CanTalk = false;

    }

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

    /*
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.Name);
        nameText.text = dialogue.Name;
        sentences.Clear();

        foreach (string setence in dialogue.sentences)
        {
            sentences.Enqueue(setence);
        }

        DisplayNextSentence();
    }
    */
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
        Time.timeScale = 1;
        isTalk = false;
        hideDialouge();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (CanTalk == true)
        {
            // Pressess the Z button to interact
            if (interactSuccess)
            {
                Debug.Log("interact");
                if (gameObject.GetComponent<AudioSource>() != null)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                }
                if (isTalk == false)
                {
                    if (Time.timeScale == 1)
                    {
                        Time.timeScale = 0;
                        showDialouge();
                        ProcessDialouge(CurrentSpeech);
                        isTalk = true;

                    }
                    else if (Time.timeScale == 0)
                    {
                        Time.timeScale = 1;
                        hideDialouge();
                    }
                }
                else
                {
                    //Debug.Log("Z button was pressed - continue");
                    DisplayNextSentence();
                }
            }


        }

    }



    void hideDialouge()
    {
        foreach (GameObject g in DialougeBoxes)
        {
            g.SetActive(false);
        }
    }

    void hidePaused()
    {
        foreach (GameObject g in MenuBoxes)
        {
            g.SetActive(false);
        }
    }

    // Shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in MenuBoxes)
        {
            g.SetActive(true);
        }
    }

    // Shows objects with ShowOnPause tag
    public void showDialouge()
    {
        foreach (GameObject g in DialougeBoxes)
        {
            g.SetActive(true);
        }
    }

    public void setToTalk()
    {
        CanTalk = true;
    }

    public void stopTalk()
    {
        CanTalk = false;
    }

    public void setTag(string newtag)
    {
        Intertag = newtag;
    }

    public void ProcessDialouge(Dialogue dialouge)
    {
        //Debug.Log("Starting dialouge with" + dialouge.Name);
        sentences.Clear();

        nameText.text = dialouge.Name;

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    

    public void GetDialouge(Dialogue dialouge)
    {
        CurrentSpeech = dialouge;
    }

}
