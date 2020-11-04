using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endscreen : MonoBehaviour
{
    bool startBool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startBool == true)
        {
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, gameObject.GetComponent<Image>().color.a + (0.5f * Time.deltaTime));
        }   
    }

    public void startFade()
    {
        startBool = true;
    }
}
