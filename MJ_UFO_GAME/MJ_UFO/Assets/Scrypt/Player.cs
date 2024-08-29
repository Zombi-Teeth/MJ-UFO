using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score = 0;

    public float ufoSpeed = 0.025f;

    int _hp = 3;
    public int hp
    {
        get => _hp;
        set => _hp = Mathf.Clamp(value, 0, maxHP);
    }
    public int maxHP = 3;
    public GameObject beam;

    // Public variables to assign in Unity Inspector
    public float leftBoundary = -10f;  // X value at which the object wraps to the right
    public float rightBoundary = 10f;  // X value at which the object wraps to the left


    // -player can move left and right
    // -can move up and down
    // - can turn on the beam
    // when on one side of the screen, goes to the other side. 



    void Start()
    {
        // if statement that says, when I press A go left



        // if statement that says, when I press D go right
        // if statement that says, when I press W go in
        // if statement that says, when I press S go out





    }



    // Update is called once per frame


    //If the object goes past a certain X, teleport to another X



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            beam.gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            beam.gameObject.SetActive(false);
        }

        // Get the current X position of the GameObject
        float xPos = transform.position.x;

        // Check if the GameObject has crossed the right boundary
        if (xPos > rightBoundary)
        {
            // Teleport to the left boundary
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);
        }
        // Check if the GameObject has crossed the left boundary
        else if (xPos < leftBoundary)
        {
            // Teleport to the right boundary
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
        }



    }

    private void FixedUpdate()
    {
       


        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-ufoSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(ufoSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, 0, ufoSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, 0, -ufoSpeed);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            HandleDamage();
           
        }
    }

    void HandleDamage()
    {
        if (_hp > 0)
        {
            hp--;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

