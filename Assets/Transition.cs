using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    public int transition = 0;
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(transition);
    }
}
