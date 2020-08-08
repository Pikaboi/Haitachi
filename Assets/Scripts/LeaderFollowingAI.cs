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
    private Movement moveScript;

    private bool activeLeader = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();

        moveScript = GetComponent<Movement>();

        if(gameObject.tag == "Player")
        {
            moveScript.enabled = true;
            //activeLeader = true;
        } else
        {
            moveScript.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0,0,0);

        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float point = 0f;

            if (plane.Raycast(ray, out point))
            {
                Vector3 movePos = ray.GetPoint(point);

                float dis = Vector3.Distance(movePos, transform.position);

                //Debug.Log(dis);
                //Debug.Log(movePos - transform.position);

                if(dis <= 1 && dis >= -1)
                {
                    isleader = true;
                    isInfected = false;
                    moveScript.enabled = true;
                    activeLeader = true;
                }
            }
        }

        if(activeLeader == false)
        {
            moveScript.enabled = false;
        }

        if (isInfected)
        {
            //float distance = Vector2.Distance(transform.forward, target.transform.forward);
            float dist = Vector3.Distance(transform.position, target.position);

            if (dist < 4.0f)
            {
                Vector3 dirToPlayer = transform.position - target.transform.position;
                Vector3 newPos = transform.position + dirToPlayer;
                Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
                transform.position += transform.right * speed * Time.deltaTime;
                // transform.position += newPos;
            }
            else if (dist < 6.0f)
            {
                //Vector3 dirToPlayer = transform.position - target.transform.position;
                //Vector3 newPos = transform.position + dirToPlayer;
                //transform.position -= newPos;
            }
            else
            {
                Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            //transform.LookAt(target.transform);
            //transform.position += transform.forward * 1f * Time.deltaTime;

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isleader != true)
        {
            if (collision.collider.tag == "Player" && isInfected == false)
            {
                isInfected = true;
                counterScript.addInfected();
            }

            if (collision.collider.gameObject.GetComponent<LeaderFollowingAI>() != null)
            {
                if (collision.collider.gameObject.GetComponent<LeaderFollowingAI>().activeLeader == true && isInfected == false)
                {
                    isInfected = true;
                    counterScript.addInfected();
                    target = collision.gameObject.GetComponent<Transform>();
                }
            }
        }
        
    }

}
