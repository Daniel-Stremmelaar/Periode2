using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float speed;
    private Vector3 v;
    private Vector3 r;
    public float rotSpeed;

    public Rigidbody body;
    public Vector3 e;
    public bool mayJump;
    public int jumpCurrent;
    public int jumpMax;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //rotation look
        r.y = Input.GetAxis("Mouse X");
        transform.Rotate(r * rotSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            if (mayJump == true)
            {
                body.velocity = e;
                jumpCurrent++;
                if (jumpCurrent >= jumpMax)
                {
                    mayJump = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        //movement back-front & left-right
        v.x = Input.GetAxis("Horizontal");
        v.z = Input.GetAxis("Vertical");
        transform.Translate(v * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "Terrain")
        {
            jumpCurrent = 0;
            mayJump = true;
        }
    }
}
