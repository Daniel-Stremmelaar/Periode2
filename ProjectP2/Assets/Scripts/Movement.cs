using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float speed;
    public float rotSpeed;
    public Rigidbody body;
    public Vector3 velocity;

    [Header("")]
    public bool mayJump;
    public int jumpCurrent;
    public int jumpMax;

    private Vector3 v;
    private Vector3 r;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Look();
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Terrain")
        {
            jumpCurrent = 0;
            mayJump = true;
        }
    }

    //movement back-front & left-right
    private void Move()
    {
        v.x = Input.GetAxis("Horizontal");
        v.z = Input.GetAxis("Vertical");
        transform.Translate(v * speed * Time.deltaTime);
    }

    //jumping
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (mayJump == true)
            {
                body.velocity = velocity;
                jumpCurrent++;
                if (jumpCurrent >= jumpMax)
                {
                    mayJump = false;
                }
            }
        }
    }

    //look left and right
    private void Look()
    {
        r.y = Input.GetAxis("Mouse X");
        transform.Rotate(r * rotSpeed * Time.deltaTime);
    }
}
