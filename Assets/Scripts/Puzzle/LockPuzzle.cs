﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LockPuzzle : MonoBehaviour
{
    public Text[] texts;

    public StartLockPuzzle starter;

    GlobalController cont;

    private float num;
    private float lockNum;

    public string answer;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
        //cont.keys.LockPuzzle.Control.started += ctx => num++;
    }

    private void OnEnable()
    {
        cont.controller.LockPuzzle.NumUp.started += ctx => num++;
        cont.controller.LockPuzzle.NumDown.started += ctx => num--;
        cont.controller.LockPuzzle.LockLeft.started += ctx => NextSlot((int)lockNum - 1);
        cont.controller.LockPuzzle.Lockright.started += ctx => NextSlot((int)lockNum + 1);
        cont.keys.LockPuzzle.NumUp.started += ctx => num++;
        cont.keys.LockPuzzle.NumDown.started += ctx => num--;
        cont.keys.LockPuzzle.LockLeft.started += ctx => NextSlot((int)lockNum - 1);
        cont.keys.LockPuzzle.Lockright.started += ctx => NextSlot((int)lockNum + 1);

        cont.controller.LockPuzzle.Exit.performed += ctx => {
            cont.controller.LockPuzzle.Disable();
            cont.controller.Game.Enable();
            cont.keys.LockPuzzle.Disable();
            cont.keys.Game.Enable();
            starter.hidePaused();
        };

        cont.keys.LockPuzzle.Exit.performed += ctx => {
            cont.controller.LockPuzzle.Disable();
            cont.controller.Game.Enable();
            cont.keys.LockPuzzle.Disable();
            cont.keys.Game.Enable();
            starter.hidePaused();
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        num = Mathf.Clamp(num, 0.0f, 9.0f);
        lockNum = Mathf.Clamp(lockNum, 0.0f, 3.0f);

        texts[(int)lockNum].text = "" + (int)num;

        string answerstr = "";
        for (int i = 0; i < texts.Length; i++)
        {
            answerstr += texts[i].text;
        }

        if(answerstr == answer)
        {
            cont.controller.LockPuzzle.Disable();
            cont.controller.Game.Enable();
            cont.keys.LockPuzzle.Disable();
            cont.keys.Game.Enable();
            starter.complete = true;
        }
    }

    void NextSlot(int newLockNum)
    {
        lockNum = newLockNum;
        num = float.Parse(texts[(int)lockNum].text);
    }
}
