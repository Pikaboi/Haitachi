using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level6 : MonoBehaviour
{
    GameObject[] objs;
    float timer = 3.0f;
    int obj = 0;

    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("Follower");
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;

        if (timer <= 0)
        {
            timer = 3.0f;
            if(image.enabled == true)
            {
                SceneManager.LoadScene(0);
                timer = 6.0f;
            }

            if(obj == 20)
            {
                image.enabled = true;
            }

            
            Destroy(objs[obj]);
            obj = obj + 1;
        }
    }
}
