using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CompPuzzleCursor : MonoBehaviour
{
    GlobalController cont;
    Camera cam;

    private Vector2 mousePos;
    public bool held;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();

        cont.keys.CompPuzzle.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cont.keys.CompPuzzle.Move.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        cont.keys.CompPuzzle.Move.canceled += ctx => mousePos = Vector2.zero;
        cont.keys.CompPuzzle.Hold.performed += ctx => held = true;
        cont.keys.CompPuzzle.Hold.canceled += ctx => held = false;

        gameObject.GetComponent<RectTransform>().transform.position = mousePos;
    }
}
