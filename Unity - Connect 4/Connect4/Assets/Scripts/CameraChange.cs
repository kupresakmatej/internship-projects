using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraChange
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera active = null;

    public static bool IsActive(CinemachineVirtualCamera camera)
    {
        return camera == active;
    }

    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        active = camera;

        foreach(CinemachineVirtualCamera c in cameras)
        {
            if(c != camera && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }
    }

    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }

    public static void Delete(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }
}
