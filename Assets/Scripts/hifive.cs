using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class hifive : MonoBehaviour
{
    GlobalController cont;
    bool colbool = false;
    GameObject CurrentNPC;

    public ParticleSystem particle;
    public AudioSource hifivesource;

    public Animator m_Animator;

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
        hifivesource.Stop();
        particle.Stop();
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            m_Animator.SetBool("isHigh", false);
        }
    }

    private void Hi5()
    {
        particle.transform.position = new Vector3(CurrentNPC.transform.position.x, CurrentNPC.transform.position.y + 10.0f, CurrentNPC.transform.position.z);
        particle.Play();
        hifivesource.Play();
        m_Animator.SetBool("isHigh", true);
        CurrentNPC.GetComponent<Infector>().beginInfect();
    }
}
