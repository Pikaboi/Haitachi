using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompPuzzlePiece : MonoBehaviour
{
    public GameObject endGoal;
    public GameObject cursor;
    private bool beingHeld = false;
    public bool matched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cursor.GetComponent<CompPuzzleCursor>().held == true && cursor.GetComponent<CompPuzzleCursor>().currentHeld == null)
        {
            if (Vector3.Distance(transform.position, cursor.transform.position) <= 20.0f)
            {
                beingHeld = true;
                cursor.GetComponent<CompPuzzleCursor>().currentHeld = gameObject;
            }

            if(beingHeld == true)
            {
                transform.position = cursor.transform.position;
            }
        } else
        {
            beingHeld = false;
            cursor.GetComponent<CompPuzzleCursor>().currentHeld = null;
        }

        if(Vector3.Distance(transform.position, endGoal.transform.position) <= 15.0f)
        {
            matched = true;
            gameObject.transform.position = new Vector3(-100.0f, -100.0f, 0.0f);
        }
        
    }
}
