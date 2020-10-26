using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCompPuzzle : MonoBehaviour
{
    GlobalController cont;

    GameObject[] puzzobjs;

    bool interacted = false;
    bool inZone = false;

    public bool complete = false;

    bool Taskcompleted = false;

    public TaskActivated taskScript;
    public DialogueActivated dialogueScript;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        puzzobjs = GameObject.FindGameObjectsWithTag("CompPuzzleUI");

        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (complete == true)
        {
            GetComponent<BoxCollider>().isTrigger = false;
            inZone = false;
            hidePaused();
            if (!Taskcompleted)
            {
                dialogueScript.setTask(6);
                taskScript.setTask(6);
                Taskcompleted = true;
            }
        }

        if (inZone)
        {
            cont.keys.Game.Interact.started += ctx => interacted = !interacted;
            cont.controller.Game.Interact.started += ctx => interacted = !interacted;

            if (interacted)
            {
                showPaused();
                cont.controller.Game.Disable();
                cont.controller.CompPuzzle.Enable();
                cont.keys.Game.Disable();
                cont.keys.CompPuzzle.Enable();
                interacted = false;
            }
        }
    }

    void hidePaused()
    {
        foreach (GameObject g in puzzobjs)
        {
            g.SetActive(false);
        }
    }

    // Shows objects with ShowOnPause tag
    void showPaused()
    {
        foreach (GameObject g in puzzobjs)
        {
            g.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inZone = false;
    }
}
