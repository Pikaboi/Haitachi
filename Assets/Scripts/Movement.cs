using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movespeed;
    public Rigidbody rb;

    private Vector3 movePos;
    private Ray ray;

    private Animator m_Animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float point = 0f;

            if(plane.Raycast(ray, out point)) {
                movePos = ray.GetPoint(point);
            }
        }

        transform.LookAt(movePos);
        transform.position = Vector3.MoveTowards(transform.position, movePos, movespeed * Time.deltaTime);

        m_Animator.SetBool("Iswalking", true);

        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * movespeed, rb.velocity.y, Input.GetAxis("Vertical") * movespeed);
    }
}
