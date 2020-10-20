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
    //Access to class
    Keyboard keys;
    Xbox controller;
    //Use this to check the button is pressed
    bool interactSuccess = false;
    bool contDialogue = true;

    float dialSpeed = 0.1f;
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


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        // Unpauses game if paused
        Time.timeScale = 1;

        DialougeBoxes = GameObject.FindGameObjectsWithTag("DialogueUI");
        hideDialouge();

        CanTalk = false;
        stopTalk();
    }

    
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

    public void DisplayNextSentence()
    {
        contDialogue = false;
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
       // Debug.Log(sentence);
        // dialogueText.text = sentence;
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
       
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            //Debug.Log("new letter");
            yield return new WaitForSeconds(dialSpeed);
            SpeedtheDialogue();
        }
       // Debug.Log("checking on loop");
        contDialogue = true;
    }
    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        //Time.timeScale = 1;
        isTalk = false;
        CanTalk = false;
        contDialogue = false;
        //hideDialouge();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (CanTalk == true)
        {
            // Pressess the Z button to interact
            if (interactSuccess && contDialogue)
            {
                //Debug.Log("interact");
                if (gameObject.GetComponent<AudioSource>() != null)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                }
                if (isTalk == false)
                {

                    //Time.timeScale = 0;
                    showDialouge();
                    ProcessDialouge(CurrentSpeech);
                    isTalk = true;
                }
                else
                {
                    //Debug.Log("Z button was pressed - continue");
                    //if (contDialogue == true)
                    //{

                    //contDialogue = false;
                    DisplayNextSentence();
                    //contDialogue=
                    // }
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
    private void SpeedtheDialogue()
    {
        dialSpeed = 0.1f;
        if (interactSuccess)
        {
            dialSpeed = 0.01f;
        }
    }
}
