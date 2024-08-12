using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ufoSpeed = 0.025f;

    int _hp = 3;
    public int hp
    {
        get => _hp;
        set => _hp = Mathf.Clamp(value, 0, maxHP);
    }
    public int maxHP = 3;
    public GameObject beam;




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

