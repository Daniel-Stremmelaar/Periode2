using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float speed;
    private Vector3 v;
    private Vector3 r;
    public float rotSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //rotation look
        r.y = Input.GetAxis("Mouse X");
        transform.Rotate(r * rotSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //movement back-front & left-right
        v.x = Input.GetAxis("Horizontal");
        v.z = Input.GetAxis("Vertical");
        transform.Translate(v * speed * Time.deltaTime);
    }
}
