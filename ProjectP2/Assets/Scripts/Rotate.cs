using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public bool b;
    public int speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (b == true)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
            if (transform.eulerAngles.z-360 > 60)
            {
                b = false;
            }
        }
        else
        {
            transform.Rotate(0, 0, -1 * speed * Time.deltaTime);
            if (transform.eulerAngles.z-360 < -60)
            {
                b = true;
            }
        }
        print(transform.eulerAngles.z.ToString());
    }
}
