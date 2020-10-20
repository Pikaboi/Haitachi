using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LockPuzzle : MonoBehaviour
{
    public Text[] texts;

    Keyboard keys;
    Xbox controller;

    private float num;
    private float lockNum;

    public string answer;

    void Awake()
    {
        keys = new Keyboard();
        controller = new Xbox();
        keys.LockPuzzle.Control.started += ctx => num++;
        //keys.LockPuzzle.Control.canceled += ctx => num = num;
        controller.LockPuzzle.NumUp.started += ctx => num++;
        controller.LockPuzzle.NumDown.started += ctx => num--;
        controller.LockPuzzle.LockLeft.started += ctx => lockNum--;
        controller.LockPuzzle.Lockright.started += ctx => lockNum++;
        //controller.LockPuzzle.Control.canceled += ctx => num = num;
    }

    void OnEnable()
    {
        controller.LockPuzzle.Enable();
        keys.LockPuzzle.Enable();
    }

    void OnDisable()
    {
        controller.LockPuzzle.Disable();
        keys.LockPuzzle.Disable();
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
            
        }
    }
}
