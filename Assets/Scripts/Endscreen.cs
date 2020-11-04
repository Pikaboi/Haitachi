using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endscreen : MonoBehaviour
{
    bool startBool = false;
    public GameObject endtext;
    public GameObject endtext2;
    public TaskActivated act;
    // Start is called before the first frame update
    void Start()
    {
        endtext.SetActive(false);
        endtext2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(startBool == true)
        {
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, gameObject.GetComponent<Image>().color.a + (0.5f * Time.deltaTime));
        }   

        if(gameObject.GetComponent<Image>().color.a > 0.5f)
        {
            setVisible();
            int dead = act.getDeadCount();
            endtext.GetComponent<Text>().text = "The Death Toll of the Virus has sadly increased today. The virus has now claimed the lives of " + (dead + 2) + " employees working in the ##### Office Headquarters.";
        }
    }

    public void startFade()
    {
        startBool = true;
    }

    void setVisible()
    {
        endtext.SetActive(true);
        endtext2.SetActive(true);
    }
}
