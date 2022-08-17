using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerHelper : MonoBehaviour
{
    public Transform lightObject;
    public Transform arrowObject;
    private bool rotating;
    private float lerpDuration = 2f;

    public static bool isFirstPlayer;

    void Awake()
    {
        isFirstPlayer = true;
        rotating = false;
    }

    IEnumerator RotateLight()
    {
        rotating = true;

        float time = 0;
        float angle = 0;

        if(isFirstPlayer)
        {
            angle = -90;
        }
        else
        {
            angle = 90;
        }

        Quaternion startRotation = lightObject.rotation;
        Quaternion targetRotation = lightObject.rotation * Quaternion.Euler(angle, 0, 0);

        while(time < lerpDuration)
        {
            lightObject.rotation = Quaternion.Slerp(startRotation, targetRotation, time / lerpDuration);
            time += Time.deltaTime;
            yield return null;
        }

        lightObject.rotation = targetRotation;
        rotating = false;
    }
}
