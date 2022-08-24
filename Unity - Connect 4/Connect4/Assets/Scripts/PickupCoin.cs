using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    private Vector3 mouseOffset;

    private Collider coinCollider;

    private float mouseZCoord;

    public GameObject arrow;

    public float angle;

    private static BoardLogic boardLogic;
    Logic logic;

    void Awake()
    {
        boardLogic = new BoardLogic();
        logic = new Logic(boardLogic);
        Logic.coin = new Coin();

        coinCollider = GetComponent<Collider>();
    }

    void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mouseOffset = gameObject.transform.position - GetMouseWorldPos();

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
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

     void OnMouseUp()
    {
        if(MainMenu.isSinglePlayer)
        {
            if (ColumnIndicator.collided)
            {
                StartCoroutine(MoveToPosition());

                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                arrow.SetActive(false);

                coinCollider.enabled = false;

                StartCoroutine(CoinHelper());
                StartCoroutine(RestartIndicatior());

                logic.DropIntoBoard(ColumnIndicator.column - 1, CameraRotate.helper);

                StartCoroutine(ChangePlayer());
            }
        }
        else if(!MainMenu.isSinglePlayer)
        {
            if (ColumnIndicator.collided)
            {
                StartCoroutine(MoveToPosition());

                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                arrow.SetActive(false);

                coinCollider.enabled = false;

                StartCoroutine(CoinHelper());
                StartCoroutine(RestartIndicatior());

                logic.DropIntoBoard(ColumnIndicator.column - 1, CameraRotate.helper);

                StartCoroutine(ChangePlayer());
            }
        }
    }

    IEnumerator ChangePlayer()
    {
        yield return new WaitForSeconds(3f);
        CameraRotate.helper += 1;
    }

    IEnumerator RotateCoin()
    {
        float rotateSpeed = 0.02f;

        if(!PlayerHelper.isFirstPlayer)
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
            StartCoroutine(RotateCoin());

            timeSinceStart += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, ColumnIndicator.colliderPosition, timeSinceStart);

            if(transform.position == ColumnIndicator.colliderPosition)
            {
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator CoinHelper()
    {
        yield return new WaitForSeconds(1f);

        coinCollider.enabled = true;
    }

    IEnumerator RestartIndicatior()
    {
        yield return new WaitForSeconds(2f);

        arrow.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Floor")
        {
            Rigidbody rb;

            rb = transform.GetComponent<Rigidbody>();

            rb.isKinematic = false;
        }
    }
}
