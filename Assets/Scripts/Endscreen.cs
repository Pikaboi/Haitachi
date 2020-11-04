using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endscreen : MonoBehaviour
{
    bool startBool = false;
    public GameObject endtext;
    public GameObject endtext2;

    GlobalController cont;

    // Start is called before the first frame update
    void Start()
    {
        endtext.SetActive(false);
        endtext2.SetActive(false);
        cont = GameObject.FindGameObjectWithTag("GlobalController").GetComponent<GlobalController>();
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
            cont.keys.Game.End.performed += ctx => SceneManager.LoadScene(0);
            cont.controller.Game.End.performed += ctx => SceneManager.LoadScene(0);
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
