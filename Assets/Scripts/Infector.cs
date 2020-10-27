using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infector : MonoBehaviour
{
    public ParticleSystem sys;
    // Start is called before the first frame update
    void Start()
    {
        sys.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void beginInfect()
    {
        sys.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Infector>() != null)
        {
            other.gameObject.GetComponent<Infector>().beginInfect();
        }
    }
}
