using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerHelper : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstPlayerCam;
    [SerializeField] CinemachineVirtualCamera secondPlayerCam;
    public Transform lightObject;

    private void OnEnable()
    {
        CameraChange.Register(firstPlayerCam);
        CameraChange.Register(secondPlayerCam);
        CameraChange.SwitchCamera(firstPlayerCam);
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
                while(lightObject.rotation.x != 50)
                {
                    lightObject.Rotate(Time.deltaTime * -10, 0, 0);
                }
            }
            else if(CameraChange.IsActive(firstPlayerCam))
            {
                CameraChange.SwitchCamera(secondPlayerCam);
                while (lightObject.rotation.x != 140)
                {
                    lightObject.Rotate(Time.deltaTime * 10, 0, 0);
                }
            }
        }
    }
}
