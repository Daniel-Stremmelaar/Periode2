using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBehaviour : MonoBehaviour {

    public Transform target;
    public int speed;
    public float freeze;
    public GameObject player;

	// Use this for initialization
	void Start () {
        speed = 5;
        target = GameObject.Find("Player").transform;
        player = GameObject.Find("Wizard");
	}
	
	// Update is called once per frame
	void Update () {
        if (freeze > 0)
        {
            freeze -= Time.deltaTime;
        }
        else
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            freeze = 1.0f;
            player.GetComponent<PlayerHealth>().LoseHealth(20);
        }
    }
}
