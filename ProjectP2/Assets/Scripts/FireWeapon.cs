using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWeapon : MonoBehaviour {

    public float currentAmmo;
    public float maxAmmo;
    public bool charging;
    public float chargedAmmo;
    public float cooldown;
    public GameObject projectileOne;
    public Transform launchPoint;
    public GameObject ammoText;
    public GameObject chargeText;
    public GameObject cooldownText;

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
                currentAmmo += 15 * Time.deltaTime;
                if (currentAmmo > maxAmmo)
                {
                    currentAmmo = maxAmmo;
                }
            }

            ammoText.GetComponent<Text>().text = "Mana: " + currentAmmo.ToString("F0") + "/100";
        }

        //fire weapon
        if (Input.GetButton("Fire1"))
        {
            charging = true;
            if (currentAmmo > 0)
            {
                currentAmmo -= 20 * Time.deltaTime;
                if (currentAmmo < 0)
                {
                    currentAmmo = 0;
                }

                if (chargedAmmo < 100)
                {
                    chargedAmmo += 20 * Time.deltaTime;
                }
            }

            ammoText.GetComponent<Text>().text = "Mana: " + currentAmmo.ToString("F0") + "/100";
            chargeText.GetComponent<Text>().text = "Charge: " + chargedAmmo.ToString("F0") + "/100";
        }

        if(Input.GetButtonUp("Fire1"))
        {
            chargedAmmo = Mathf.Ceil(chargedAmmo);
            if(chargedAmmo > 100)
            {
                chargedAmmo = 100;
            }
            FireProjectile((int) chargedAmmo);
            charging = false;
            chargedAmmo = 0;
            chargeText.GetComponent<Text>().text = "Charge: " + chargedAmmo.ToString("F0") + "/100";
        }

        //activated ability
        if (Input.GetButtonDown("Fire2"))
        {
            //verschilt per character
            if(cooldown == 0)
            {
                currentAmmo = 100.0f;
                cooldown = 30.0f;
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
        cooldownText.GetComponent<Text>().text = "Cooldown: " + cooldown.ToString("F0") + " sec";
    }

    void FireProjectile(int dmg)
    {
        GameObject g = Instantiate(projectileOne, launchPoint.position, launchPoint.rotation);
        dmg *= 12;
        g.GetComponent<Projectile>().damage = dmg;
        print("shoot for " + dmg.ToString() + " damage");
    }
}
