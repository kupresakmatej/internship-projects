using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    private Vector3 mouseOffset;

    private float mouseZCoord;

    private float lerpDuration = 1f;

    public float speed;

   void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mouseZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mouseOffset;
    }

    private void OnMouseUp()
    {
        if(ColumnIndicator.collided)
        {
            StartCoroutine(MoveToPosition());

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    IEnumerator RotateCoin()
    {
        float rotateSpeed = 0.02f;
        float angle = 90;

        if(CameraRotate.isFirstPlayer)
        {
            angle = -90;
        }
        else
        {
            angle = 90;
        }

        Quaternion correctRotation = Quaternion.Euler(90, 90, angle);

        while (transform.rotation != correctRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(90, 90, angle), rotateSpeed * Time.time);
            yield return null;
        }

        transform.rotation = correctRotation;
    }

    IEnumerator MoveToPosition()
    {
        float timeSinceStart = 0f;

        while(true)
        {
            timeSinceStart += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, ColumnIndicator.colliderPosition, timeSinceStart);

            if(transform.position == ColumnIndicator.colliderPosition)
            {
                yield break;
            }

            StartCoroutine(RotateCoin());
            yield return null;
        }
    }
}
