using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    private float rotationSpeed = 0.1f;
    public GameObject pivotObject;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            RotateCamera();
        }
    }

    void RotateCamera()
    {
        while(transform.position.z < 26 && transform.rotation.y < 180)
        {
            transform.RotateAround(pivotObject.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
        }
    }
}
