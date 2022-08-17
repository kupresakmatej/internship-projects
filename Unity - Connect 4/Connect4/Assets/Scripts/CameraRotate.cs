using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform lightObject;

    public Transform arrowObject;

    float angles;

    MainMenu menu;
    public GameObject Menu;

    public static int helper = 0;

    private BoardLogic board;

    private bool isDone;

    void Awake()
    {
        PlayerHelper.isFirstPlayer = true;
        helper = 0;
        angles = transform.rotation.y;

        menu = Menu.GetComponent<MainMenu>();

        board = new BoardLogic();
        board.ClearBoard();

        isDone = false;

        StopAllCoroutines();
    }

    void Update()
    {
        if(!Logic.GameOver())
        {
            Time.timeScale = 1;

            if (helper % 2 == 0 && PlayerHelper.isFirstPlayer)
            {
                PlayerHelper.isFirstPlayer = !PlayerHelper.isFirstPlayer;

                StartCoroutine(RotateCamera());
                StartCoroutine(RotateLight());

                arrowObject.rotation = Quaternion.Euler(0, -90, 90);
            }
            else if (helper % 2 != 0 && !PlayerHelper.isFirstPlayer)
            {
                PlayerHelper.isFirstPlayer = !PlayerHelper.isFirstPlayer;

                StartCoroutine(RotateCamera());
                StartCoroutine(RotateLight());

                arrowObject.rotation = Quaternion.Euler(0, 90, 90);
            }
        }
        else
        {
            if(!isDone)
            {
                board.ClearBoard();
                menu.GameOver();
                //Time.timeScale = 0;
                isDone = true;
            }
        }
    }

    IEnumerator RotateCamera()
    {
        float speed = 2f;

        if (PlayerHelper.isFirstPlayer)
        {
            angles = -180;
        }
        else
        {
            angles = 0;
        }

        Quaternion correctRotation = Quaternion.Euler(0, angles, 0);

        while (this.transform.rotation != correctRotation)
        {
            transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, angles, 0), speed);
            yield return null;
        }

        this.transform.rotation = correctRotation;
    }

    IEnumerator RotateLight()
    {
        float rotateSpeed = 1f;
        float angle = lightObject.rotation.y;

        if(PlayerHelper.isFirstPlayer)
        {
            angle = 140;
        }
        else
        {
            angle = 50;
        }

        Quaternion correctRotation = Quaternion.Euler(angle, -30, 0);

        while (lightObject.rotation != correctRotation)
        {
            lightObject.rotation = Quaternion.RotateTowards(lightObject.rotation, Quaternion.Euler(angle, -30, 0), rotateSpeed);
            yield return null;
        }

        lightObject.rotation = correctRotation;
    }
}
