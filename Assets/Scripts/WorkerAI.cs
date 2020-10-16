using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerAI : MonoBehaviour
{
    public float speed;

    private Transform target;

    private Transform myself;
    public Rigidbody rb;
    private bool isInfected = false;

    private Animator m_Animator;

    public float moveSpeed = 10.0f;
    public float rotSpeed = 100.0f;

    private bool isWalking = true;
    private bool newdes = true;

    public NavMeshAgent agent;
    Vector3 movePos;


    Vector3 First;
    Vector3 Second;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();

        m_Animator = gameObject.GetComponent<Animator>();

        myself = GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();


        First = new Vector3(9.1f, -0.4166666f, 23.0f);
        Second = new Vector3(-13.06f, -0.4166666f, -5.71f);
        m_Animator.SetBool("Iswalking", true);
        movePos = First;
        agent.SetDestination(movePos);
    }

    // Update is called once per frame
    void Update()
    {
        if (movePos == transform.position)
        {
            m_Animator.SetBool("Iswalking", true);
            //movePos = target.transform.position;
            if (newdes == false)
            {
                movePos = First;
            }
            else
            {
                movePos = Second;
            }
            newdes = !(newdes);
            agent.SetDestination(movePos);

        }
        if (isWalking == true)
        {

            //before
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;

            //after
            //agent.SetDestination(target.transform.position);
        }
    }

    private void RotationDirection()
    {
        Vector3 dirToPlayer = transform.position - target.transform.position;
        Vector3 newPos = transform.position + dirToPlayer;
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        //transform.Rotate(transform.rotation.x, 0, transform.rotation.z, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")
        {
            //RotationDirection();
            //agent.SetDestination(target.transform.position);
            m_Animator.SetBool("ishifive", true);
            //m_Animator.SetBool("Iswalking", false);
            //agent.isStopped = true;

        }
        if (collision.collider.tag == "Block")
        {
            isWalking = false;
            //RotationDirection();
            //m_Animator.SetBool("ishifive", true);

        }


    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            
           // 
            //agent.isStopped = false;
            m_Animator.SetBool("ishifive", false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_Animator.SetBool("Iswalking", false);
            agent.isStopped = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // Debug.Log("exit");
            agent.isStopped = false;
            m_Animator.SetBool("Iswalking", true);
        }
    }
}
