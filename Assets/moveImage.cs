using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class moveImage : MonoBehaviour, IPointerDownHandler
{
    GlobalController cont;

    bool held = false;

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
        cont.keys.CompPuzzle.Held.performed += ctx => held = true;
        cont.keys.CompPuzzle.Held.canceled += ctx => held = false;
    }

    public void OnPointerDown(PointerEventData eventdata)
    {
        Debug.Log("haha");
    }
}
