using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerHelper : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstPlayerCam;
    [SerializeField] CinemachineVirtualCamera secondPlayerCam;

    public Transform lightObject;
    private bool rotating;
    private float lerpDuration = 2f;

    private bool isFirstPlayer;

    private void OnEnable()
    {
        CameraChange.Register(firstPlayerCam);
        CameraChange.Register(secondPlayerCam);
        CameraChange.SwitchCamera(firstPlayerCam);

        isFirstPlayer = true;
    }

    private void OnDisable()
    {
        CameraChange.Delete(firstPlayerCam);
        CameraChange.Delete(secondPlayerCam);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(CameraChange.IsActive(secondPlayerCam))
            {
                CameraChange.SwitchCamera(firstPlayerCam);
                isFirstPlayer = true;

                StartCoroutine(RotateLight());
            }
            else if(CameraChange.IsActive(firstPlayerCam) && !rotating)
            {
                CameraChange.SwitchCamera(secondPlayerCam);
                isFirstPlayer = false;

                StartCoroutine(RotateLight());
            }
        }
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
