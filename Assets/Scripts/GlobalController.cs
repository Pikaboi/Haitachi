using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public Keyboard keys;
    public Xbox controller;

    void Awake()
    {
        keys = new Keyboard();
        controller = new Xbox();
    }
    void OnEnable()
    {
        controller.Game.Enable();
        keys.Game.Enable();
    }

    void OnDisable()
    {
        controller.Game.Disable();
        keys.Game.Disable();
    }
}
