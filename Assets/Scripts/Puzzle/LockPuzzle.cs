using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LockPuzzle : MonoBehaviour
{
    public Text[] texts;

    GlobalController cont;

    private float num;
    private float lockNum;

    public string answer;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
        cont.keys.LockPuzzle.Control.started += ctx => num++;
        cont.controller.LockPuzzle.NumUp.started += ctx => num++;
        cont.controller.LockPuzzle.NumDown.started += ctx => num--;
        cont.controller.LockPuzzle.LockLeft.started += ctx => lockNum--;
        cont.controller.LockPuzzle.Lockright.started += ctx => lockNum++;
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
            GameObject[] puzzobjs = GameObject.FindGameObjectsWithTag("LockPuzzleUI");

            foreach (GameObject go in puzzobjs)
            {
                go.SetActive(false);
            }

            cont.controller.LockPuzzle.Disable();
            cont.controller.Game.Enable();
        }
    }
}
