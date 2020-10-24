using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompPuzzlePiece : MonoBehaviour
{
    public GameObject endGoal;
    public GameObject cursor;
    private bool beingHeld = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cursor.GetComponent<CompPuzzleCursor>().held == true)
        {
            if (Vector3.Distance(transform.position, cursor.transform.position) <= 10.0f)
            {
                beingHeld = true;
            }

            if(beingHeld == true)
            {
                transform.position = cursor.transform.position;
            }
        } else
        {
            beingHeld = false;
        }

        if(Vector3.Distance(transform.position, endGoal.transform.position) <= 15.0f)
        {
            Debug.Log("success!");
        }
        
    }
}
