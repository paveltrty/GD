using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 6f;
    public float horSens = 10;
    public GameObject main_cam;
    public float jumpForce = 10;
    public float health = 100;
    
    private Rigidbody rb;
    private bool isGrounded;

    private Rayshoot shoot;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();

        shoot = GetComponent<Rayshoot>();
        health = 80;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }
    
    void Update()
    {
        var hor_move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var vert_move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(hor_move, 0, vert_move);
        if (Input.GetButtonDown("Fire1"))
        {
            shoot.Shoot();
        }
        float rot_x = Input.GetAxis("Mouse X") * horSens * Time.deltaTime;

        transform.Rotate(0, rot_x, 0);
    }

    private void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }

    public bool Healed(float delta)
    {
        if (health == 100)
        {
            return false;
        }
        else
        {
            health += delta;
            Debug.Log(health);
            return true;
            
        }
    }
    
}
