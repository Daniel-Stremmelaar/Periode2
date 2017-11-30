using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;
    public Vector3 v;
    public float speed;

	// Use this for initialization
	void Start () {
        v.z = 1;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Target>().LoseHP(damage);
            Destroy(gameObject, 0.1f);
        }
    }
}
