using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    public int transition = 0;
    public Transform warpPos;
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = warpPos;
    }
}
