using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour {

    public float currentAmmo;
    public float maxAmmo;
    public bool charging;
    public float chargedAmmo;
    public float cooldown;
    public GameObject projectileOne;
    public Transform launchPoint;

	// Use this for initialization
	void Start () {
        maxAmmo = 100;
        currentAmmo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update () {
        //regen ammo
        if(charging == false)
        {
            if (currentAmmo < maxAmmo)
            {
                currentAmmo += 10 * Time.deltaTime;
                if (currentAmmo > maxAmmo)
                {
                    currentAmmo = maxAmmo;
                }
            }
        }

        //fire weapon
        if (Input.GetButton("Fire1"))
        {
            charging = true;
            if(currentAmmo > 0)
            {
                currentAmmo -= 10 * Time.deltaTime;
                if(currentAmmo < 0)
                {
                    currentAmmo = 0;
                }
            }

            if(chargedAmmo < 100)
            {
                chargedAmmo += 10 * Time.deltaTime;
            }
        }

        if(Input.GetButtonUp("Fire1"))
        {
            chargedAmmo = Mathf.Ceil(chargedAmmo);
            if(chargedAmmo > 100)
            {
                chargedAmmo = 100;
            }
            print("shoot for " + chargedAmmo.ToString() + " damage");
            FireProjectile((int) chargedAmmo);
            charging = false;
            chargedAmmo = 0;
        }

        //activated ability
        if (Input.GetButtonDown("Fire2"))
        {
            //verschilt per character
            if(cooldown == 0)
            {
                print("ability");
                cooldown = 15.0f;
            }
            else
            {
                print("on cooldown");
            }
        }

        //cooldown timer
        cooldown -= Time.deltaTime;
        if (cooldown < 0)
        {
            cooldown = 0;
        }
    }

    void FireProjectile(int dmg)
    {
        GameObject g = Instantiate(projectileOne, launchPoint.position, launchPoint.rotation);
        g.GetComponent<Projectile>().damage = dmg;
    }
}
