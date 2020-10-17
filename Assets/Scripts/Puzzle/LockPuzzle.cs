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

    private Vector2 movedata;

    float value = 0;
    float slot = 0;

    void Awake()
    {
        keys = new Keyboard();
        controller = new Xbox();

        keys.LockPuzzle.Control.performed += ctx => movedata = ctx.ReadValue<Vector2>();
        keys.LockPuzzle.Control.canceled += ctx => movedata = Vector2.zero;
        controller.LockPuzzle.Control.performed += ctx => movedata = ctx.ReadValue<Vector2>();
        controller.LockPuzzle.Control.canceled += ctx => movedata = Vector2.zero;
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
        value += Mathf.Ceil(movedata.x);

        Mathf.Clamp(value, 0, 9);

        Debug.Log(value);
        slot += Mathf.Ceil(movedata.y);

        Mathf.Clamp(slot, 0, 4);

        int x = (int)slot;

        texts[x].text = "" + value;
    }
}
