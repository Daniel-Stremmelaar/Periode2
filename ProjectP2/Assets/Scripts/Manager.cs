using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public bool paused;
    public GameObject player;
    public GameObject mainCamera;
    public GameObject weapon1;
    public GameObject pauseMenu;
    public Button resumeButton;
    public Button quitButton;
    public GameObject StaffAmmoText;
    public GameObject StaffChargeText;
    public GameObject StaffCooldownText;
    public bool switched;
    public GameObject BookAmmoText;
    public GameObject BookCooldownText;

	// Use this for initialization
	void Start () {
        resumeButton.onClick.AddListener(Unpause);
        quitButton.onClick.AddListener(QuitGame);
	}
	
	// Update is called once per frame
	void Update () {
        //pause game
        if (Input.GetButtonDown("Cancel"))
        {
            paused = true;
        }

        //turn on/off menu
		if(paused == true)
        {
            Time.timeScale = 0;
            player.GetComponent<Movement>().enabled = false;
            mainCamera.GetComponent<LookUpDown>().enabled = false;
            weapon1.GetComponent<FireWeapon>().enabled = false;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            player.GetComponent<Movement>().enabled = true;
            mainCamera.GetComponent<LookUpDown>().enabled = true;
            weapon1.GetComponent<FireWeapon>().enabled = true;
            pauseMenu.SetActive(false);
        }
	}

    public void Unpause()
    {
        paused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void WeaponUiSwitch()
    {
        switched = !switched;
        if(switched == true)
        {
            StaffAmmoText.SetActive(false);
            StaffChargeText.SetActive(false);
            StaffCooldownText.SetActive(false);
            BookAmmoText.SetActive(true);
            BookCooldownText.SetActive(true);
        }
        if(switched == false)
        {
            StaffAmmoText.SetActive(true);
            StaffChargeText.SetActive(true);
            StaffCooldownText.SetActive(true);
            BookAmmoText.SetActive(false);
            BookCooldownText.SetActive(false);
        }
    }

}
