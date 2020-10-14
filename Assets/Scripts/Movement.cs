using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    Xbox inputSys;
    public float movespeed;
    public Rigidbody rb;

    private Vector3 movePos;
    private Ray ray;

    private Animator m_Animator;

    AudioSource move;

    private Vector2 movedata;

    void Awake()
    {
        inputSys = new Xbox();

        inputSys.Game.Move.performed += ctx => movedata = ctx.ReadValue<Vector2>();
        inputSys.Game.Move.canceled += ctx => movedata = Vector2.zero;
    }

    void OnEnable()
    {
        inputSys.Game.Enable();
    }

    void OnDisable()
    {
        inputSys.Game.Disable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        m_Animator = gameObject.GetComponent<Animator>();

        move = gameObject.GetComponent<AudioSource>();

        move.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m = new Vector3(movedata.x, 0, movedata.y) * 10 * Time.deltaTime;
        transform.Translate(m, Space.Self);

        m_Animator.SetBool("Iswalking", true);
        if (move.isPlaying == false)
        {
            move.PlayOneShot(move.clip);
        }

        
    }
}
