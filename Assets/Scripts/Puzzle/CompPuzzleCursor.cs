using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CompPuzzleCursor : MonoBehaviour
{
    public GameObject[] nodes;

    GlobalController cont;

    public StartCompPuzzle starter;

    private Vector2 mousePos = new Vector2(500.0f, 350.0f);
    private Vector2 moveData;
    public bool held;

    public GameObject currentHeld;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cont.keys.CompPuzzle.Move.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        cont.keys.CompPuzzle.Move.canceled += ctx => mousePos = Vector2.zero;
        cont.keys.CompPuzzle.Hold.performed += ctx => held = true;
        cont.keys.CompPuzzle.Hold.canceled += ctx => held = false;

        cont.controller.CompPuzzle.Move.performed += ctx => moveData = ctx.ReadValue<Vector2>();
        cont.controller.CompPuzzle.Move.canceled += ctx => moveData = Vector2.zero;
        cont.controller.CompPuzzle.Hold.performed += ctx => held = true;
        cont.controller.CompPuzzle.Hold.canceled += ctx => held = false;

        cont.controller.CompPuzzle.Exit.performed += ctx => {
            cont.controller.CompPuzzle.Disable();
            cont.controller.Game.Enable();
            cont.keys.CompPuzzle.Disable();
            cont.keys.Game.Enable();
            starter.hidePaused();
        };

        cont.keys.CompPuzzle.Exit.performed += ctx => {
            cont.controller.CompPuzzle.Disable();
            cont.controller.Game.Enable();
            cont.keys.CompPuzzle.Disable();
            cont.keys.Game.Enable();
            starter.hidePaused();
        };

        gameObject.transform.position = mousePos;

        Vector3 m = new Vector3(moveData.x, moveData.y, 0) * 1000 * Time.deltaTime;
        transform.Translate(m, Space.World);

        if(gameObject.transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }

        if (gameObject.transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        if (gameObject.transform.position.x > 1000)
        {
            transform.position = new Vector3(1000, transform.position.y, transform.position.z);
        }

        if (gameObject.transform.position.y > 790)
        {
            transform.position = new Vector3(transform.position.x, 790, transform.position.z);
        }

        mousePos = new Vector2(transform.position.x, transform.position.y);

        int count = 0;
        foreach(GameObject go in nodes)
        {
            if (go.GetComponent<CompPuzzlePiece>().matched == true)
            {
                count++;
            }
        }

        if(count == 4)
        {
            cont.controller.CompPuzzle.Disable();
            cont.controller.Game.Enable();
            cont.keys.CompPuzzle.Disable();
            cont.keys.Game.Enable();
            starter.complete = true;
        }
    }
}
