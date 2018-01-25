using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public ParticleSystem pOne;
    public ParticleSystem pTwo;
    public ParticleSystem pThree;
    public float timer;
    public GameObject demon;
    public Vector3 v;
    public GameObject manager;

	// Use this for initialization
	void Start () {
        timer = Random.Range(6.0f, 9.0f);
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Instantiate(demon, transform.position+v, Quaternion.identity);
            timer = Random.Range(6.0f, 9.0f);
        }
	}

    public void DisableEmission()
    {
        pOne.Stop();
        pTwo.Stop();
        pThree.Stop();
        manager.GetComponent<Manager>().won = true;
    }
}
