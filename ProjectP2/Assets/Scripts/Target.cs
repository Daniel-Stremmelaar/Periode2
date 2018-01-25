using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public int hp;

	// Use this for initialization
	void Start () {
        hp = 500;
        if(gameObject.name == "Portal")
        {
            hp = 2000;
        }
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
            if(gameObject.name == "Portal")
            {
                gameObject.GetComponent<Portal>().DisableEmission();
            }
        }
    }
}
