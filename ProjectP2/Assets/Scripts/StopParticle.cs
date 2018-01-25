using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopParticle : MonoBehaviour {

    public ParticleSystem p;
    public float f;
    public float l;
    public bool b;

	// Use this for initialization
	void Start () {
        p = gameObject.GetComponent<ParticleSystem>();
        f = 0.15f;
        l = 0.15f;
        b = false;
	}
	
	// Update is called once per frame
	void Update () {
        f -= Time.deltaTime;
        if (f <= 0)
        {
            p.Stop();
            Destroy(gameObject, 0.1f);
        }
	}
}
