using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

    public GameObject staff;
    public GameObject book;
    public bool switched;

	// Use this for initialization
	void Start () {
        switched = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire3"))
        {
            switched = !switched;
            if (switched == true)
            {
                staff.SetActive(false);
                book.SetActive(true);
            }
            if(switched == false)
            {
                staff.SetActive(true);
                book.SetActive(false);
            }
        }
	}
}
