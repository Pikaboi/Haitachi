using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    Keyboard keys;
    Xbox controller;
    public float movespeed;
    public Rigidbody rb;

    private Vector2 movedata;

    bool onController = true;

    void Awake()
    {
        keys = new Keyboard();
        controller = new Xbox();

        keys.Game.Move.performed += ctx => movedata = ctx.ReadValue<Vector2>();
        keys.Game.Move.canceled += ctx => movedata = Vector2.zero;
        controller.Game.Move.performed += ctx => movedata = ctx.ReadValue<Vector2>();
        controller.Game.Move.canceled += ctx => movedata = Vector2.zero;
    }

    void swapControl()
    {
        onController = !onController;
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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //movePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m = new Vector3(movedata.x, 0, movedata.y) * 10 * Time.deltaTime;
        transform.Translate(m, Space.Self);
    }
}
