using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public int maxHealth;
    public GameObject loseText;
    public GameObject healthText;
    public GameObject mainCamera;
    public GameObject quitButton;
    public GameObject weapon1;
    public GameObject crosshair;
    public GameObject crosshair2;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mainCamera.GetComponent<LookUpDown>().enabled = false;
            quitButton.SetActive(true);
            weapon1.GetComponent<FireWeapon>().enabled = false;
            health = 0;
            healthText.GetComponent<Text>().text = "Health: " + health.ToString();
            loseText.SetActive(true);
            Time.timeScale = 0;
            crosshair.SetActive(false);
            crosshair2.SetActive(false);
        }
        else
        {
            healthText.GetComponent<Text>().text = "Health: " + health.ToString();
        }
    }

    public void GainHealth(int heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthText.GetComponent<Text>().text = "Health: " + health.ToString();
    }
}
