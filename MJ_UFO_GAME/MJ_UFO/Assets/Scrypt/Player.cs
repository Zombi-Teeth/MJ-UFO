using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    // -player can move left and right
    // -can move up and down
    // - can turn on the beam
    // when on one side of the screen, goes to the other side. 
   


    void Start()
    {
        // if statement that says, when I press A go left
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(0.025f, 0, 0);
        }


        // if statement that says, when I press D go right
        // if statement that says, when I press W go in
        // if statement that says, when I press S go out
        



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
