using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class hifive : MonoBehaviour
{
    GlobalController cont;
    bool colbool = false;
    GameObject CurrentNPC;

    void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
    }

    private void OnEnable()
    {
      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colbool == true)
        {
            cont.controller.Game.Hi5.started += ctx => Hi5();
            cont.keys.Game.Hi5.started += ctx => Hi5();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "NPC")
        {
            colbool = true;
            CurrentNPC = other.gameObject;
        }
    }

    private void Hi5()
    {
        CurrentNPC.GetComponent<Infector>().beginInfect();
    }
}
