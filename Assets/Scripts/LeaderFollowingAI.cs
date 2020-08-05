using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeaderFollowingAI : MonoBehaviour
{
    public float speed;
    private Transform target;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0,0,0);
        //float distance = Vector2.Distance(transform.forward, target.transform.forward);
        float dist = Vector3.Distance(transform.position, target.position);
        Debug.Log("Distance to other: " + dist);

        if (dist < 2.0f)
        { 
            //Vector3 dirToPlayer = transform.position - target.transform.position;
            //Vector3 newPos = transform.position + dirToPlayer;
            //transform.position -= newPos;
        }
        else
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        //transform.LookAt(target.transform);
        //transform.position += transform.forward * 1f * Time.deltaTime;

        

    }
}
