using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskActivated : MonoBehaviour
{

    GameObject[] DialougeBoxes;
    GameObject[] MenuBoxes;
    GameObject[] NPCbox;
    GameObject[] dyingBox;
    GameObject[] InfectedBox;

    public GameObject workers;
    private bool CanTalk;
    private string Intertag;
    private bool isTalk;
    private bool isdead = false;

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

    int TaskNum = 0;
    int each = 0;

    int dyingBoxCount = 0;

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
        DialougeBoxes = GameObject.FindGameObjectsWithTag("TaskUI");
        InfectedBox = GameObject.FindGameObjectsWithTag("Infected");
        hideDialouge();
        hideInfect();
        CanTalk = false;
        stopTalk();
    }


    public void StartDialogue(Dialogue dialogue)
    {
       /// Debug.Log("Starting conversation with " + dialogue.Name);
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
        //Debug.Log(sentence);
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
            yield return new WaitForSeconds(0.01f);
            
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
        NPCbox = GameObject.FindGameObjectsWithTag("NPC");
        dyingBox = new GameObject[14];
        /*int count = 0;
        foreach (GameObject g in NPCbox) {
            if(g.GetComponent<Infector>() != null)
            {
                count++;
            }
        }
        dyingBox = new GameObject[count];*/

        int numcount = 0;
        foreach (GameObject g in NPCbox)
        {
            if (g.GetComponent<Infector>() != null)
            {
                Infector inf = g.GetComponent<Infector>();
                if (inf.dying)
                {
                    dyingBox[numcount] = g;
                    numcount++;
                }
            }
        }

        if (CanTalk == true)
        {
            // Pressess the Z button to interact
            if (interactSuccess && contDialogue)
            {
                //Debug.Log(TaskNum);
                if (gameObject.GetComponent<AudioSource>() != null)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                }
                if (isTalk == false)
                {
                    //Debug.Log("interact");
                    //Debug.Log(TaskNum);

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
    public void hideInfect()
    {
        foreach (GameObject g in InfectedBox)
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
        contDialogue = true;
    }

    public void stopTalk()
    {
        CanTalk = false;
        contDialogue = true;
    }

    public void setTag(string newtag)
    {
        Intertag = newtag;
    }

    public void ProcessDialouge(Dialogue dialouge)
    {
        //Debug.Log("Starting dialouge with" + dialouge.Name);
        sentences.Clear();
        //Debug.Log(dialouge.sentences[0]);
        nameText.text = dialouge.Name;

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        ProgressionOnLevel();
        DisplayNextSentence();
    }

    public void setTask(int n)
    {
        sentences.Clear();
        //Debug.Log(dialouge.sentences[0]);
        nameText.text = "!";
        TaskNum = n;
        if (n ==2 || n == 6)
        {
            sentences.Enqueue("Go To Boss");

        }
        //isTalk = true;
        DisplayNextSentence();
        //setToTalk();


    }
    public void SetWorkersToDead()
    {
        foreach (GameObject g in dyingBox) {
            g.SetActive(false);
            g.GetComponent<Infector>().corpse.SetActive(true);
            g.GetComponent<Infector>().corpse.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public int getTask()
    {
        return TaskNum;
    }
    //A NOTE FOR BRADEN AND THE OTHERS
    //HOW THE CODE WORKS IS BY ORDER ON HOW YOU WANT THE GAME TO PLAY DIFFERENTLY
    //MEANING THINK OF THE MANY BRANCHES PATHS THE PLAYER COULD GO WITH AND APPLY
    private void ProgressionOnLevel()
    {
        string sentence = sentences.Dequeue();

        //Debug.Log(sentence);
        //Debug.Log(TaskNum);
        switch (TaskNum)
        {
            case 0: //Branch 0
                if (sentence == "Go find Lucas")
                {
                    //Debug.Log("Boss assigned");
                    sentences.Enqueue("Get the files from cabinet");
                    TaskNum = 1;
                    //sentences.Enqueue(sentence);
                }
                break;
            case 1: //branch 1
                    //if (sentence == "Go To Boss") //lucas
                    //{
                    //    //TaskNum = 2;
                    //sentences.Enqueue(sentence);
                    //}
                    //else if (sentence == "Go find Lucas")
                    // {
                    //sentences.Enqueue("Water the plants");
                    //Debug.Log("Have the boss talk");
                    //sentences.Dequeue();
                    //sentences.Enqueue("Go Find Lucas dammit");
                    //Debug.Log("the topic change");
                    //TaskNum = 2;
                    //   sentences.Enqueue(sentence);

                // }
                if (sentence == "Go find Lucas") //Boss
                {

                    //Debug.Log("New Assignment");
                    //sentences.Enqueue(sentence);
                    //sentences.Enqueue(sentence);
                    //TaskNum = 3;

                }
                else if(sentence == "Go To Boss")
                {

                }
                else if(sentence == "Deliver Coffee to the boss")
                {

                }
                else
                {
                    sentences.Enqueue(sentence);
                }
                break;

            case 2: //Task one Completed
                if (sentence == "Go find Lucas") //Boss
                {

                    //Debug.Log("New Assignment");
                    //Debug.Log(sentence);
                    sentences.Enqueue("Go find Lucas");
                    TaskNum = 3;

                }
                else if(sentence == "Go To Boss")
                {

                }
                else if(sentence == "Deliver Coffee to the boss")
                {

                }
                else
                {
                    sentences.Enqueue(sentence);
                }
                break;
            case 3: //Task two started
                if (sentence == "Go To Boss")
                {
                    //Debug.Log("New Assignment");
                    sentences.Enqueue(sentence);
                    TaskNum = 4;
                }
                else if (sentence == "Go find Lucas")
                {
                    //Debug.Log("Boss assigned");
                    //sentences.Enqueue("Get the files from cabinet");
                    //TaskNum = 4;
                    //sentences.Enqueue(sentence);
                    sentences.Enqueue(sentence);
                }
                else if(sentence == "Deliver Coffee to the boss")
                {

                }
                else
                {
                    sentences.Enqueue(sentence);
                }
                break;
            case 4: //Task two finished
                if (sentence == "Go find Lucas")
                {
                    //Debug.Log("Boss assigned");
                    sentences.Enqueue("Get the PC fixed");
                    TaskNum = 5;
                    //sentences.Enqueue(sentence);
                }
                else if(sentence == "Go To Boss")
                {

                }
                else if(sentence == "Deliver Coffee to the boss")
                {

                }
                else
                {
                    sentences.Enqueue(sentence);
                }
                break;
            case 5: //Task three started
                if (sentence == "Go find Lucas")
                {
                    //Debug.Log("Boss assigned");
                    //sentences.Enqueue("Get the files from cabinet");
                    //TaskNum = 1;
                    //sentences.Enqueue(sentence);
                }
                else if(sentence == "Go To Boss")
                {

                }
                else if(sentence == "Deliver Coffee to the boss")
                {

                }
                else
                {
                    sentences.Enqueue(sentence);
                }
                break;
            case 6: //Task three finished
                if (sentence == "Go find Lucas")
                {
                    //Debug.Log("Boss assigned");
                    sentences.Enqueue("Get the coffee");
                    TaskNum = 7;
                    //sentences.Enqueue(sentence);
                }
                else if(sentence == "Go To Boss")
                {

                }
                else if(sentence == "Deliver Coffee to the boss")
                {

                }
                else
                {
                    sentences.Enqueue(sentence);
                }
                break;
            case 7: //promoted 
                if (sentence == "Deliver Coffee to the boss")
                {
                    //Debug.Log("Boss assigned");
                    sentences.Enqueue("Go to Boss");
                    TaskNum = 8;
                    SetWorkersToDead();
                    //sentences.Enqueue(sentence);
                }
                else if(sentence == "Go To Boss")
                {

                }
                else if(sentence == "Go find Lucas")
                {
                }
                else if (sentence == "Deliver Coffee to the boss")
                {

                }
                    break;
            case 8: //promoted 
                if (sentence == "Go find Lucas")
                {
                    //Debug.Log("Boss assigned")
                    //sentences.Enqueue("Get the coffee");
                    TaskNum = 9;
                    Debug.Log("THEEND");
                    //sentences.Enqueue(sentence);
                }
                break;
            default:
                break;
        }
    }

    public void GetDialouge(Dialogue dialouge)
    {
        CurrentSpeech = dialouge;
    }
}
