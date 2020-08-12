using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeaderFollowingAI : MonoBehaviour
{
    public float speed;
    private Transform target;
    public Rigidbody rb;
    private bool isInfected = false;

    public ExtendCam counterScript;

    private bool isleader = false;
    
    private Animator m_Animator;

    GameObject[] objs;

    AudioSource hiFive;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();

        counterScript = Camera.main.GetComponent<ExtendCam>();

        objs = GameObject.FindGameObjectsWithTag("Enemy");

        m_Animator = gameObject.GetComponent<Animator>();

        hiFive = gameObject.GetComponent<AudioSource>();

        hiFive.Stop();

        if(gameObject.tag == "Follower")
        {
            isInfected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0,0,0);

        if (gameObject.tag == "Follower")
        {
            Debug.Log(isInfected);
        }

        if (isInfected == true && isleader == false)
        {
            if (m_Animator != null)
            {
                m_Animator.SetBool("ishifive", true);
            }

            //float distance = Vector2.Distance(transform.forward, target.transform.forward);
            float dist = Vector3.Distance(transform.position, target.position);

            if (dist < 4.0f)
            {
                if (m_Animator != null)
                {
                    m_Animator.SetBool("Iswalking", true);
                }
                Vector3 dirToPlayer = transform.position - target.transform.position;
                Vector3 newPos = transform.position + dirToPlayer;
                Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
                transform.position += transform.right * speed * Time.deltaTime;
                // transform.position += newPos;
            }
            else if (dist < 6.0f)
            {
                if (m_Animator != null)
                {
                    m_Animator.SetBool("ishifive", false);
                    m_Animator.SetBool("Iswalking", false);
                }
                //Vector3 dirToPlayer = transform.position - target.transform.position;
                //Vector3 newPos = transform.position + dirToPlayer;
                //transform.position -= newPos;
            }
            else
            {
                if (m_Animator != null)
                {
                    m_Animator.SetBool("Iswalking", true);
                }
                Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            //transform.LookAt(target.transform);
            //transform.position += transform.forward * 1f * Time.deltaTime;

        }

    }
    public bool getInfected()
    {
        return isInfected;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isleader != true)
        {
            if (collision.collider.tag == "Player" && isInfected == false)
            {
                hiFive.PlayOneShot(hiFive.clip);
                isInfected = true;
                counterScript.addInfected();
            }
        }
        
    }

}
