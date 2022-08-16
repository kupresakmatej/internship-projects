using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseObject;
    public GameObject restartObject;
    public GameObject startObject;
    public GameObject continueObject;
    public GameObject blurFirst;
    public GameObject blurSecond;
    public GameObject victoryText;

    void Start()
    {
        gameObject.SetActive(true);
        pauseObject.SetActive(false);
        restartObject.SetActive(false);
        continueObject.SetActive(false);

        blurFirst.SetActive(true);
        blurSecond.SetActive(false);

        victoryText.SetActive(false);

        restartObject.SetActive(false);
        victoryText.SetActive(false);

        Time.timeScale = 1;
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        pauseObject.SetActive(true);

        blurFirst.SetActive(false);
        blurSecond.SetActive(false);

        restartObject.SetActive(false);
        victoryText.SetActive(false);

        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        if(!CameraRotate.isFirstPlayer)
        {
            blurFirst.SetActive(true);
            blurSecond.SetActive(false);
        }
        else if(CameraRotate.isFirstPlayer)
        {
            blurSecond.SetActive(true);
            blurFirst.SetActive(false);
        }

        gameObject.SetActive(true);
        restartObject.SetActive(true);
        continueObject.SetActive(true);

        startObject.SetActive(false);
        pauseObject.SetActive(false);
    }

    public void RestartGame()
    {
        restartObject.SetActive(false);
        victoryText.SetActive(false);

        Application.LoadLevel(Application.loadedLevel);
    }

    public void ContinueGame()
    {
        gameObject.SetActive(false);

        pauseObject.SetActive(true);

        blurFirst.SetActive(false);
        blurSecond.SetActive(false);

        restartObject.SetActive(false);
    }

    public void GameOver()
    {
        victoryText.SetActive(true);
        restartObject.SetActive(true);
        pauseObject.SetActive(false);

        blurSecond.SetActive(true);
    }    
}
