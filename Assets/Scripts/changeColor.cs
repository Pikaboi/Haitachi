using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    public Material[] materials;
    public Renderer rend;
    public LeaderFollowingAI AIscriptName;
    // Material[] materials1101 = GetComponent<Renderer>().material;
    //public Material m_Material_line;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        //GetComponent<Renderer>().material.color = Color.red;
        //m_Material_body = GetComponent<Renderer>().material;
        //m_Material_body.color =  Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (AIscriptName.getInfected())
        {
            GetComponent<Renderer>().material = materials[1];
        }
        //rend.sharedMaterial = materials[0];
    }
}
