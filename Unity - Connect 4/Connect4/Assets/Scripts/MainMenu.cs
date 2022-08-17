using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameMode;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject blurPlaneF;
    public GameObject blurPlaneS;
    public GameObject gameOverMenu;

    public bool isSinglePlayer;
    private bool plane;

    void Awake()
    {
        mainMenu.SetActive(true);

        gameOverMenu.SetActive(false);
    }

    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        if(mainMenu.activeSelf)
        {
            gameOverMenu.SetActive(false);
        }
    }

    public void StartSPGame()
    {
        Time.timeScale = 1;

        mainMenu.SetActive(false);
        pauseButton.SetActive(true);

        gameMode.SetActive(false);

        blurPlaneF.SetActive(false);
        blurPlaneF.SetActive(false);

        isSinglePlayer = true;
    }

    public void StartMPGame()
    {
        PlayerHelper.isFirstPlayer = true;
        CameraRotate.helper = 0;

        Time.timeScale = 1;

        mainMenu.SetActive(false);
        pauseButton.SetActive(true);

        gameMode.SetActive(false);

        blurPlaneF.SetActive(false);
        blurPlaneF.SetActive(false);

        isSinglePlayer = false;
    }

    public void GameMode()
    {
        mainMenu.SetActive(false);

        gameMode.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        if(PlayerHelper.isFirstPlayer)
        {
            plane = true;
        }
        else if(!PlayerHelper.isFirstPlayer)
        {
            plane = false;
        }

        if(!plane)
        {
            blurPlaneF.SetActive(true);
            blurPlaneS.SetActive(false);

            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
        }
        else
        {
            blurPlaneF.SetActive(false);
            blurPlaneS.SetActive(true);

            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
        }
        
    }

    public void RestartPause()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContinueGame()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);

        blurPlaneF.SetActive(false);
        blurPlaneS.SetActive(false);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);

        if (!plane)
        {
            blurPlaneF.SetActive(true);
            blurPlaneS.SetActive(false);
        }
        else
        {
            blurPlaneF.SetActive(false);
            blurPlaneS.SetActive(true);
        }
    }    
}
