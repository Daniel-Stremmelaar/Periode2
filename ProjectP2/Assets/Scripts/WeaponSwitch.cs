using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

    public GameObject staff;
    public GameObject book;
    public bool switched;
    public GameObject cameraPlayer;
    public GameObject weaponManager;

	// Use this for initialization
	void Start () {
        switched = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                switched = !switched;
                cameraPlayer.GetComponent<FireBook>().enabled = switched;
                weaponManager.GetComponent<Manager>().WeaponUiSwitch();
                if (switched == true)
                {
                    staff.SetActive(false);
                    book.SetActive(true);
                }
                if (switched == false)
                {
                    staff.SetActive(true);
                    book.SetActive(false);
                }
            }
        }
	}
}
