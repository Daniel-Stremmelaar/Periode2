using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBook : MonoBehaviour {

    private RaycastHit hit;
    public GameObject impact; //particle effect
    public GameObject g; //instantiated particle effect
    public int damage;
    public int ammo;
    public int maxAmmo;
    public float charge;
    public float timer;
    public GameObject ammoText;
    public GameObject cooldownText;
    public GameObject playerBody;

    // Use this for initialization
    void Start () {
        ammo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update () {
        //charge ammo
        charge += Time.deltaTime;
        if(charge >= 2.5f)
        {
            if (ammo < maxAmmo)
            {
                ammo++;
                ammoText.GetComponent<Text>().text = "Ammo: " + ammo.ToString() + "/" + maxAmmo.ToString();
            }
            charge = 0;
        }

        //cooldown timer
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = 0;
        }
        cooldownText.GetComponent<Text>().text = "Cooldown: " + timer.ToString("F0") + " sec";

        //fire weapon
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo > 0)
            {
                Debug.DrawRay(transform.position, transform.forward * 10, Color.black);
                if (Physics.Raycast(transform.position, transform.forward, out hit, 1000.0f))
                {
                    if (hit.transform.tag == "Enemy")
                    {
                        print("succes");
                        Instantiate(impact, hit.point, Quaternion.identity);
                        hit.transform.gameObject.GetComponent<Target>().LoseHP(damage);
                    }
                }
                ammo--;
                ammoText.GetComponent<Text>().text = "Ammo: " + ammo.ToString() + "/" + maxAmmo.ToString();
            }
        }

        //special ability
        if (Input.GetButtonDown("Fire2"))
        {
            if(timer > 0)
            {
                print("cooldown");
            }
            else
            {
                //ability effect
                playerBody.GetComponent<PlayerHealth>().GainHealth(25);
                timer = 10.0f;
                cooldownText.GetComponent<Text>().text = "Cooldown: " + timer.ToString("F0") + " sec";
            }
        }
    }
}
