using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;
    public Vector3 v;
    public float speed;
    public float timer;
    public float size;
    public Vector3 scale;

	// Use this for initialization
	void Start () {
        v.z = 1;
        size = damage / 12;
        size = Mathf.Pow(Mathf.Pow(5.0f, 0.01f), size);
        size = Mathf.Floor(size);
        scale.x = size;
        scale.y = size;
        scale.z = size;
        transform.localScale = scale;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //life timer
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject, 0.1f);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Target>().LoseHP(damage);
            Destroy(gameObject, 0.01f);
        }
    }
}
