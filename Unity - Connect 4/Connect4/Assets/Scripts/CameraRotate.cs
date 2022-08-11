using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform lightObject;

    public static bool isFirstPlayer;

    public Transform arrowObject;

    float angles;

    private void Awake()
    {
        isFirstPlayer = true;
        angles = transform.rotation.y;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(RotateCamera());
            StartCoroutine(RotateLight());

            isFirstPlayer = !isFirstPlayer;

            if(isFirstPlayer)
            {
                arrowObject.rotation = Quaternion.Euler(0, -90, 90);
            }
            else
            {
                arrowObject.rotation = Quaternion.Euler(0, 90, 90);
            }
        }
    }

    IEnumerator RotateCamera()
    {
        float speed = 0.05f;

        if (isFirstPlayer)
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
            transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, angles, 0), speed);
            yield return null;
        }

        this.transform.rotation = correctRotation;
    }

    IEnumerator RotateLight()
    {
        float rotateSpeed = 0.01f;
        float angle = lightObject.rotation.y;

        if(isFirstPlayer)
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
            lightObject.rotation = Quaternion.Slerp(lightObject.rotation, Quaternion.Euler(angle, -30, 0), rotateSpeed * Time.time);
            yield return null;
        }

        lightObject.rotation = correctRotation;
    }
}
