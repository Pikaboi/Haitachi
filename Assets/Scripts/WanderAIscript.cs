using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WanderAIscript : MonoBehaviour
{
    public float speed;

    private Transform target;

    private Transform myself;
    public Rigidbody rb;
    private bool isInfected = false;

    private Animator m_Animator;

    public float moveSpeed = 10.0f;
    public float rotSpeed = 100.0f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();

        m_Animator = gameObject.GetComponent<Animator>();

        myself = GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isWandering ==false)
        {
            
            StartCoroutine(Wander());
        }
        if(isRotatingRight == true)
        {
            transform.Rotate(transform.up, Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up, Time.deltaTime * -rotSpeed);
        }
        if(isWalking==true )
        {
            m_Animator.SetBool("Iswalking", true);
            //before
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;

            //after
            agent.SetDestination(transform.position + (transform.forward* moveSpeed));
        }
    }


    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(0, 3);

        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        m_Animator.SetBool("Iswalking", false);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);

        if(rotateLorR==1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft =true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;
        

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
            m_Animator.SetBool("ishifive", true);

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
            m_Animator.SetBool("ishifive", false);

        }

    }
}
