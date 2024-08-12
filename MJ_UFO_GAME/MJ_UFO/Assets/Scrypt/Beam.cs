using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    // beams cows

    void Start()
    {
     
    }

    private void turnoff()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cow")
        { 
            Destroy(other.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
