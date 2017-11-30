using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public int hp;

	// Use this for initialization
	void Start () {
        hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoseHP(int dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
