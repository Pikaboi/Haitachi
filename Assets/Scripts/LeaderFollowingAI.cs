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

    GameObject[] objs;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();

        objs = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0,0,0);

        if (isInfected == true && isleader == false)
        {
            //float distance = Vector2.Distance(transform.forward, target.transform.forward);
            float dist = Vector3.Distance(transform.position, target.position);

            if (dist < 2.0f)
            {
                Vector3 dirToPlayer = transform.position - target.transform.position;
                Vector3 newPos = transform.position + dirToPlayer;
                Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
                transform.position += transform.right * speed * Time.deltaTime;
                // transform.position += newPos;
            }
            else if (dist < 4.0f)
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
                isInfected = true;
                counterScript.addInfected();
            }
        }
        
    }

}
