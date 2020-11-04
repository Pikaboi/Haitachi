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

    public AudioSource TalkSFX;

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
        TalkSFX.Stop();
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
            TalkSFX.Play();
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
                    sentences.Enqueue("I wanted to talk with you, and before you ask, you are not in trouble.");
                    sentences.Enqueue("This is for your promotion, your working hard but I need to trust you with tasks.");
                    sentences.Enqueue("My first task for you is getting some files from the cabinet.");
                    sentences.Enqueue("It's locked, you remember the combination?");
                    TaskNum = 1;
                    TaskREquired = true;

                }
                if (nameText.text == "Reception")
                {
                    sentences.Enqueue("You should get going to the elevator.");
                    sentences.Enqueue("The boss wants you on the upper floor.");
                }
                if (nameText.text == "Anothony")
                {
                    sentences.Enqueue("Aren't you suppose to be in a meeting?");
                }
                if (nameText.text == "Cassidy")
                {
                    sentences.Enqueue("Boss is at the usual spot.");
    
                }
                if (nameText.text == "Charlie")
                {
                    sentences.Enqueue("W-where is the boss?");
                    sentences.Enqueue("S-sorry i don't know...");
                }
                if (nameText.text == "Dave")
                {
                    sentences.Enqueue("Aren't you suppose to be in a meeting?");
                    sentences.Enqueue("Eh? Where is the meeting?");
                    sentences.Enqueue("It's in the meeting room to my right...");
                }
                if (nameText.text == "Ella")
                {
                    sentences.Enqueue("...Boss is looking for you...");
                    sentences.Enqueue("...Hope you aren't in trouble...");
                }
                if (nameText.text == "Hayley")
                {
                    //CHANGE LATER
                    sentences.Enqueue("The Boss wanted to talk to you.");
                    sentences.Enqueue("I hope it isn't bad.");
                }
                if (nameText.text == "Joshua")
                {
                    //CHANGE LATER
                    sentences.Enqueue("the Boss wanted to talk to you.");
                    sentences.Enqueue("I hope it isn't bad");
                }
                if (nameText.text == "Katherine")
                {
                    //CHANGE LATER
                    sentences.Enqueue("The Boss wanted to talk to you.");
                    sentences.Enqueue("I hope it isn't bad.");
                }

                if (nameText.text == "Lucas")
                {

                    sentences.Enqueue("The Boss wanted to talk to you.");
                    sentences.Enqueue("I hope it isn't bad.");
                    //sentences.Enqueue("Go find Lucas he should be at his desk");
                }
                if (nameText.text == "Rebecca")
                {
                    sentences.Enqueue("Boss was looking for you.");
                    sentences.Enqueue("Your in big trouble now!");
                }
                if (nameText.text == "Sarah")
                {
                    sentences.Enqueue("Oh yeah boss wants you!");
                }
                if (nameText.text == "Thomas")
                {
                    sentences.Enqueue("Oh yeah boss was looking for ya!");
                }
                if (nameText.text == "Zack")
                {
                    sentences.Enqueue("Boss is in his office.");
                }
                break;

            case 1: //task one started (the lock)
                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("I dont see those files in your hands...");
                    sentences.Enqueue("The cabinet is in the office area, you should remember the combination.");
                    sentences.Enqueue("Otherwise ask your co-workers if the locks been changed.");
                    sentences.Enqueue("Once you get the files come back to me.");
                    //TaskNum = 1;

                }
                if (nameText.text == "Anothony")
                {
                    sentences.Enqueue("Huh? Files? Oh, it should be here...");
                }
                if (nameText.text == "Cassidy")
                {
                    sentences.Enqueue("Combination may be with Sarah... I think?");

                }
                if (nameText.text == "Charlie")
                {
                    sentences.Enqueue("Huh? C-cabinet? It's here somewhere b-but I dont know the combination?");
                    sentences.Enqueue("S-sorry!");
                }
                if (nameText.text == "Dave")
                {
                    sentences.Enqueue("Cabinet? I dont know, I just know it has a combination.");

                }
                if (nameText.text == "Ella")
                {
                    sentences.Enqueue("...Umm, its on your Right, the cabinet.");
                    sentences.Enqueue("...The combination should be with one of the guys...");
                }
                if (nameText.text == "Joshua")
                {
      
                    sentences.Enqueue("Oh the cabinet is at the corner.");
                    sentences.Enqueue("The combination is 4286...Alright?");
                }
                if (nameText.text == "Sarah")
                {
                    //CHANGE LATER
                    sentences.Enqueue("Oh the files, they are at a cabinet near my desk but I forgot the combination...");
                    sentences.Enqueue("Joshua may know since he set up the combination.");
                }
               
                break;

            case 2: //Task one Completed
                //taskText.ResetTask();
                if (Intertag == "Boss")
                {

                    taskText.ResetTask();
                    sentences.Enqueue("Ah the files, well done!");
                    sentences.Enqueue("Now i require some paper that needs to be printed.");
                    sentences.Enqueue("Can you retrieve some papers from Lucas?");

                    TaskNum = 3;

                }
                break;

            case 3: //Task two started
                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("I see no papers in your hands...");
                    sentences.Enqueue("The one who has those papers is named Lucas, he is in the office right now.");
                    sentences.Enqueue("Once you get those papers come back to me.");
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
                    sentences.Enqueue("He is at work today thats all i can say!");
                }
                if (nameText.text == "Katherine")
                {
                    //CHANGE LATER
                    sentences.Enqueue("Oh lucas? You can find him yourself.");
                }

                if (nameText.text == "Lucas")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("Oh you want the papers?");
                    sentences.Enqueue("Here you go, give them to the boss!");
                    TaskNum = 4;
                    //sentences.Enqueue("Go find Lucas he should be at his desk");
                }
                if (nameText.text == "Rebecca")
                {
                    sentences.Enqueue("Where is Lucas? As if i will tell you.");
                }
                if (nameText.text == "Sarah")
                {
                    sentences.Enqueue("Oh I saw Lucas, he should be at the Group Meeting Room.");
                }
                if (nameText.text == "Thomas")
                {
                    sentences.Enqueue("Lucas was just leaving his space, I saw him with some papers.");
                }
                if (nameText.text == "Zack")
                {
                    sentences.Enqueue("He not in the toilets or in the meeting...");
                }
                break;

            case 4: //Task two finished
                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("I see you got the paper, great!");
                    sentences.Enqueue("Now the final task to prove you deserve that promotion.");
                    sentences.Enqueue("One of the Computer's needs it's files organized.");
                    sentences.Enqueue("It also seems to have a Computer Virus.");
                    sentences.Enqueue("Go fix the Computer and report back to me.");
                    TaskNum = 5;

                }
                break;
            case 5: //Task three started

                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("I'm guessing you haven’t really found which computer to fix?");
                    sentences.Enqueue("I got the complaints from Dave on it.");
                    sentences.Enqueue("Go talk to him, otherwise check his computer yourself.");
                    

                }
                if (nameText.text == "Charlie")
                {
                    sentences.Enqueue("Huh? M-My computer is fine...");
                    sentences.Enqueue("S-Sorry, maybe its someone else...");
                }
                if (nameText.text == "Dave")
                {
                    sentences.Enqueue("Finally! Its over at my desk... Hurry up! That virus makes the Computer run awfully.");

                }
                if (nameText.text == "Ella")
                {
                    sentences.Enqueue("...I think its Dave, he was swearing very loudly yesterday...");
                    sentences.Enqueue("...maybe his computer broke?");
                }
                if (nameText.text == "Hayley")
                {
                    //CHANGE LATER
                    sentences.Enqueue("What? Computer?");
                    sentences.Enqueue("Mine is, like, fine");
                }
                if (nameText.text == "Sarah")
                {
                    sentences.Enqueue("I think the computer you are looking at is one of the males here...");
                }
                if (nameText.text == "Thomas")
                {
                    sentences.Enqueue("Computer fixing? Well I heard yelling in the office so...maybe there?");
                }
                if (nameText.text == "Zack")
                {
                    sentences.Enqueue("Computers are usually in the office since we need them.");
                }
                break;
            case 6: //Task three completed
                if (Intertag == "Boss")
                {
                    taskText.ResetTask();

                    sentences.Enqueue("You fixed the computer? Amazing!!");
                    sentences.Enqueue("Congratulations, I can now confidently give you your well deserved promotion!");
                    sentences.Enqueue("And with that, go early to lunch. You deserved it!");

                    TaskNum = 7;



                }
                break;
            case 7: //get coffeee
                if (nameText.text == "Reception")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("Hm? Coffee?");
                    sentences.Enqueue("Oh the boss's coffee, its right here");
                    sentences.Enqueue("here you go");
                    TaskNum = 8;
                }
                break;
            case 8: //get coffeee
                if (Intertag == "Boss")
                {
                    taskText.ResetTask();
                    sentences.Enqueue("Thanks for the coffee...*cough*");
                    sentences.Enqueue("Sorry i dont feel good...i think im gonna go home");
                    sentences.Enqueue("...did something happpen?");
                    TaskNum = 9;

                    GameObject endscreen = GameObject.FindGameObjectWithTag("EndScren");
                    endscreen.GetComponent<Endscreen>().startFade();
                }
                break;
            default:
                break;
        }
    }
}
