using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public Animator anim;
    private bool StartBool = false;
    private float timer = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (StartBool == true)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene(1);
            }
            Debug.Log(timer);
        }
        
    }

    public void StartGame()
    {
        anim.SetTrigger("Clap");
        StartBool = true;
    }
}
