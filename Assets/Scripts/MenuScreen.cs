using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    GlobalController cont;

    public GameObject text;

    private Vector2 mousePos = new Vector2(500.0f, 350.0f);
    private bool start = false;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cont.controller.Menu.Enable();
        cont.keys.Menu.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        cont.keys.Menu.Move.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        cont.keys.Menu.Move.canceled += ctx => mousePos = Vector2.zero;
        cont.keys.Menu.Closegame.performed += ctx => Application.Quit();

        cont.controller.Menu.Start.performed += ctx => start = true;
        cont.controller.Menu.Start.canceled += ctx => start = false;

        transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        if(Vector3.Distance(transform.position, text.transform.position) <= 20.0f)
        {
            cont.keys.Menu.Hold.performed += ctx => start = true;
            cont.keys.Menu.Hold.canceled += ctx => start = false;
        }

        if(start == true)
        {
            SceneManager.LoadScene(1);
        }

    }
}
