using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLockPuzzle : MonoBehaviour
{
    GlobalController cont;

    GameObject[] puzzobjs;

    bool interacted = false;
    bool inZone = false;

    public bool complete = false;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        puzzobjs = GameObject.FindGameObjectsWithTag("LockPuzzleUI");

        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if(complete == true)
        {
            GetComponent<BoxCollider>().isTrigger = false;
            inZone = false;
            hidePaused();
        }

        if (inZone)
        {
            cont.keys.Game.Interact.started += ctx => interacted = !interacted;
            cont.controller.Game.Interact.started += ctx => interacted = !interacted;

            if (interacted)
            {
                showPaused();
                cont.controller.Game.Disable();
                cont.controller.LockPuzzle.Enable();
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
