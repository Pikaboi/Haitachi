using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    GlobalController cont;
    public float movespeed;
    public Rigidbody rb;

    private Vector2 movedata;

    bool onController = true;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
    }

    void swapControl()
    {
        onController = !onController;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //movePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        cont.keys.Game.Move.performed += ctx => movedata = ctx.ReadValue<Vector2>();
        cont.keys.Game.Move.canceled += ctx => movedata = Vector2.zero;
        cont.controller.Game.Move.performed += ctx => movedata = ctx.ReadValue<Vector2>();
        cont.controller.Game.Move.canceled += ctx => movedata = Vector2.zero;

        Vector3 m = new Vector3(movedata.x, 0, movedata.y) * 10 * Time.deltaTime;
        transform.Translate(m, Space.Self);
    }
}
