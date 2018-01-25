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
    public GameObject staffAmmoText;
    public GameObject staffChargeText;
    public GameObject staffCooldownText;
    public bool switched;
    public GameObject bookAmmoText;
    public GameObject bookCooldownText;
    public GameObject winText;
    public GameObject quit;
    public float timer;
    public bool won;
    public GameObject crosshair;
    public GameObject crosshair2;

	// Use this for initialization
	void Start () {
        resumeButton.onClick.AddListener(Unpause);
        quitButton.onClick.AddListener(QuitGame);
        Time.timeScale = 0;
        player.GetComponent<Movement>().enabled = false;
        mainCamera.GetComponent<LookUpDown>().enabled = false;
        weapon1.GetComponent<FireWeapon>().enabled = false;
        crosshair.SetActive(false);
        timer = 3.0f;
        won = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
        //pause game
        if (Input.GetButtonDown("Cancel"))
        {
            paused = true;
            Pause();
        }
        if(won == true)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            WinCondition();
        }
	}

    public void Unpause()
    {
        paused = false;
        Pause();
        if(switched == true)
        {
            crosshair.SetActive(true);
            crosshair2.SetActive(false);
        }
        else
        {
            crosshair.SetActive(false);
            crosshair2.SetActive(true);
        }
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
            staffAmmoText.SetActive(false);
            staffChargeText.SetActive(false);
            staffCooldownText.SetActive(false);
            bookAmmoText.SetActive(true);
            bookCooldownText.SetActive(true);
            crosshair.SetActive(true);
            crosshair2.SetActive(false);
        }
        if(switched == false)
        {
            staffAmmoText.SetActive(true);
            staffChargeText.SetActive(true);
            staffCooldownText.SetActive(true);
            bookAmmoText.SetActive(false);
            bookCooldownText.SetActive(false);
            crosshair.SetActive(false);
            crosshair2.SetActive(true);
        }
    }

    public void WinCondition()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        print("win");
        winText.SetActive(true);
        Time.timeScale = 0;
        player.GetComponent<Movement>().enabled = false;
        mainCamera.GetComponent<LookUpDown>().enabled = false;
        weapon1.GetComponent<FireWeapon>().enabled = false;
        quit.SetActive(true);
        crosshair.SetActive(false);
        crosshair2.SetActive(false);
    }

    public void Pause()
    {
        //turn on/off menu
        if (paused == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            player.GetComponent<Movement>().enabled = false;
            mainCamera.GetComponent<LookUpDown>().enabled = false;
            weapon1.GetComponent<FireWeapon>().enabled = false;
            pauseMenu.SetActive(true);
            quit.SetActive(true);
            crosshair.SetActive(false);
            crosshair2.SetActive(false);
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            player.GetComponent<Movement>().enabled = true;
            mainCamera.GetComponent<LookUpDown>().enabled = true;
            weapon1.GetComponent<FireWeapon>().enabled = true;
            pauseMenu.SetActive(false);
            quit.SetActive(false);
            if (switched == true)
            {
                crosshair.SetActive(true);
                crosshair2.SetActive(false);
            }
        }
    }

}
