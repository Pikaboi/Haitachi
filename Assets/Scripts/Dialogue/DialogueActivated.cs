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

    private TaskText taskText;
    //this is for new input
    //Access to class
    Keyboard keys;
    Xbox controller;
    //Use this to check the button is pressed
    bool interactSuccess = false;
    bool contDialogue = true;

    float dialSpeed = 0.1f;

    int TaskNum = 0;
    bool TaskComplete = true;

    bool TaskREquired = false;
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
       
        // Debug.Log(sentence);
        // dialogueText.text = sentence;
       
        string sentence = sentences.Dequeue();

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
     //   Debug.Log("End of conversation.");
        //Time.timeScale = 1;
        isTalk = false;
        CanTalk = false;
        contDialogue = false;
        if (taskText != null && TaskREquired == true)
        {
            taskText.GiveTask();

        }
        hideDialouge();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (CanTalk == true)
        {
            // Pressess the Z button to interact
            if (interactSuccess && contDialogue)
            {
               // Debug.Log("interact");
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
        contDialogue = true;
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

        //if (Intertag == "Boss")
        // {

        //    if (TaskComplete == true)
        //     {
        //         sentences.Enqueue("Well done");
        //         sentences.Enqueue("Have a cookie");
        //
        //         TaskComplete = false;
        //     }



        //}
        ProgressionOnLevel();
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

        public void SetTheTask(TaskText tasktransfer)
    {
        if (tasktransfer != null)
        {
            taskText = tasktransfer;
            
        }
    }
    public void setTask(int num)
    {
        TaskNum = num;
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
        switch (TaskNum)
        {
            case 0: //when the game starts
                if (Intertag == "Boss")
                {
                    sentences.Enqueue("I wanted to talk with you, and before you ask, you are not in trouble");
                    sentences.Enqueue("This is for  your promotion, but you must prove to me");
                    sentences.Enqueue("My first task to you is getting from files from the cabinet");
                    TaskNum = 1;
                    TaskREquired = true;

                }
                if (nameText.text == "Reception")
                {
                    sentences.Enqueue("You should get going to the elevator");
                    sentences.Enqueue("You on the upper floor");
                }
                if (nameText.text == "Anothony")
                {
                    sentences.Enqueue("Arent you suppose to be in a meeting?");
                }
                if (nameText.text == "Cassidy")
                {
                    sentences.Enqueue("Boss is at the usual spot");
    
                }
                if (nameText.text == "Charlie")
                {
                    sentences.Enqueue("W-where is the boss?");
                    sentences.Enqueue("S-sorry i don't know...");
                }
                if (nameText.text == "Dave")
                {
                    sentences.Enqueue("Arent you suppose to be in a meeting?");
                    sentences.Enqueue("Eh? Where is the meeting?");
                    sentences.Enqueue("It's in the meeting room to my right..");
                }
                if (nameText.text == "Ella")
                {
                    sentences.Enqueue("...boss is looking for you");
                    sentences.Enqueue("...hope you aren't in trouble");
                }
                if (nameText.text == "Hayley")
                {
                    //CHANGE LATER
                    sentences.Enqueue("the Boss wanted to talk to you");
                    sentences.Enqueue("I hope it isn't bad");
                }
                if (nameText.text == "Joshua")
                {
                    //CHANGE LATER
                    sentences.Enqueue("the Boss wanted to talk to you");
                    sentences.Enqueue("I hope it isn't bad");
                }
                if (nameText.text == "Katherine")
                {
                    //CHANGE LATER
                    sentences.Enqueue("the Boss wanted to talk to you");
                    sentences.Enqueue("I hope it isn't bad");
                }

                if (nameText.text == "Lucas")
                {
                    sentences.Enqueue("the Boss wanted to talk to you");
                    sentences.Enqueue("I hope it isn't bad");
                    //sentences.Enqueue("Go find Lucas he should be at his desk");
                }
                if (nameText.text == "Rebecca")
                {
                    sentences.Enqueue("boss was looking for you");
                    sentences.Enqueue("You in big trouble now");
                }
                if (nameText.text == "Sarah")
                {
                    sentences.Enqueue("Oh yeah boss wants you");
                }
                if (nameText.text == "Thomas")
                {
                    sentences.Enqueue("Oh yeah boss was looking for ya");
                }
                if (nameText.text == "Zack")
                {
                    sentences.Enqueue("Boss is in his office");
                }
                break;

            case 1: //task one started (the lock)
                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("I dont see those files in your hands...");
                    sentences.Enqueue("The cabinet is in the office area, you should be able to remember the combination");
                    sentences.Enqueue("otherwise ask one of your co-workers");
                    sentences.Enqueue("once you get those files come back to me");
                    //TaskNum = 1;

                }
                if (nameText.text == "Anothony")
                {
                    sentences.Enqueue("Huh? Files? Oh, it should be here...");
                }
                if (nameText.text == "Cassidy")
                {
                    sentences.Enqueue("conbination may be with Sarah..i think?");

                }
                if (nameText.text == "Charlie")
                {
                    sentences.Enqueue("Huh? C-cabinet? It's here somewhere b-but i dont know the combination?");
                    sentences.Enqueue("S-sorry!");
                }
                if (nameText.text == "Dave")
                {
                    sentences.Enqueue("Cabinet? I dont know, i just know it has a combination");

                }
                if (nameText.text == "Ella")
                {
                    sentences.Enqueue("...umm, its on your left, the cabinet");
                    sentences.Enqueue("...the combination should be with one of the guys...");
                }
                if (nameText.text == "Joshua")
                {
      
                    sentences.Enqueue("Oh the cabinet is at the corner");
                    sentences.Enqueue("The combination is 4286...alright?");
                }
                if (nameText.text == "Sarah")
                {
                    //CHANGE LATER
                    sentences.Enqueue("Oh the files, they are at my desk but i forgot the combination");
                    sentences.Enqueue("Joshua may know since he set up the combination");
                }
               
                break;

            case 2: //Task one Completed
                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("Ah the files, well done");
                    sentences.Enqueue("now i require some paper needed to printed");
                    sentences.Enqueue("can you retrieve some papers from lucas");
                    TaskNum = 3;

                }
                break;

            case 3: //Task two started
                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("i see no papers in your hands…");
                    sentences.Enqueue("The one who has those papers is named Lucas, find his nameplate on the desk...");
                    sentences.Enqueue("once you get those papers come back to me");
                    //TaskNum = 1;

                }
                if (nameText.text == "Hayley")
                {
                    //CHANGE LATER
                    sentences.Enqueue("Wait Lucas?");
                    sentences.Enqueue("There is someone named Lucas in the office?");
                }
                if (nameText.text == "Joshua")
                {
                    //CHANGE LATER
                    sentences.Enqueue("Lucas?");
                    sentences.Enqueue("He is at work today thats all i can say");
                }
                if (nameText.text == "Katherine")
                {
                    //CHANGE LATER
                    sentences.Enqueue("Oh lucas? You can find him yourself");
                }

                if (nameText.text == "Lucas")
                {
                    sentences.Enqueue("Oh you want the papers?");
                    sentences.Enqueue("Here you go, give them to the boss!");
                    TaskNum = 4;
                    //sentences.Enqueue("Go find Lucas he should be at his desk");
                }
                if (nameText.text == "Rebecca")
                {
                    sentences.Enqueue("Where is Lucas? As if i will tell you");
                }
                if (nameText.text == "Sarah")
                {
                    sentences.Enqueue("Oh i saw lucas he should be at his desk");
                }
                if (nameText.text == "Thomas")
                {
                    sentences.Enqueue("Lucas is in his space, i saw him with some papers");
                }
                if (nameText.text == "Zack")
                {
                    sentences.Enqueue("He not in the toilets or in the meeting…");
                }
                break;

            case 4: //Task two finished
                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("I see you got the paper, great!");
                    sentences.Enqueue("now the final task to prove you deserve that promotion");
                    sentences.Enqueue("one of the pc broke down yesterday");
                    sentences.Enqueue("go repair and report back to me");
                    TaskNum = 5;

                }
                break;
            case 5: //Task three started

                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("im guessing you haven’t really found who computer to fix");
                    sentences.Enqueue("i got some complains from Dave...on his computer");
                    sentences.Enqueue("go talk to him, otherwise check his computer yourself...");
                    

                }
                if (nameText.text == "Charlie")
                {
                    sentences.Enqueue("Huh? M-My computer is fine...");
                    sentences.Enqueue("S-Sorry, maybe its someone else...");
                }
                if (nameText.text == "Dave")
                {
                    sentences.Enqueue("Finally! Its over at my desk...hurry up");

                }
                if (nameText.text == "Ella")
                {
                    sentences.Enqueue("...i think its dave, he was swearing very loudly yesterday");
                    sentences.Enqueue("...maybe his computer broke?");
                }
                if (nameText.text == "Hayley")
                {
                    //CHANGE LATER
                    sentences.Enqueue("What? Computer?");
                    sentences.Enqueue("Fine is, like, fine");
                }
                if (nameText.text == "Sarah")
                {
                    sentences.Enqueue("I think the computer you are looking at is one of the males here...");
                }
                if (nameText.text == "Thomas")
                {
                    sentences.Enqueue("Computer fixing? Well I heard yelling in the office so...maybe there");
                }
                if (nameText.text == "Zack")
                {
                    sentences.Enqueue("Computers are usually in the office since we need them");
                }
                break;
            case 6: //Task three completed
                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("You fixed the computer? amazing!!");
                    sentences.Enqueue("Congratulation, i now give you your well deserved promotion");
                    sentences.Enqueue("And with that go early to lunch you deserved it!");
                    TaskNum = 7;



                }
                break;
            default:
                break;
        }
    }
}
