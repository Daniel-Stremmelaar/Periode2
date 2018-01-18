using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public int maxHealth;
    public GameObject loseText;
    public GameObject healthText;

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
        if (health < 0)
        {
            health = 0;
            healthText.GetComponent<Text>().text = "Health: " + health.ToString();
            loseText.SetActive(true);
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
