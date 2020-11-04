using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infector : MonoBehaviour
{
    public ParticleSystem sys;
    public bool dying = false;
    public GameObject corpse;
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
        dying = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Infector>() != null)
        {
            if (sys.isPlaying == true)
            {
                other.gameObject.GetComponent<Infector>().beginInfect();
            }
        }
    }
}
