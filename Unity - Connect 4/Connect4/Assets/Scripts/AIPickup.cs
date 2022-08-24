using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPickup : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Coins;
    [SerializeField]
    private List<GameObject> Triggers;

    private static float angle;

    private int columnIdx;

    void Update()
    {
        
    }

    public IEnumerator MoveToPosition(int columnIdx, int counter)
    {
        float timeSinceStart = 0f;

        while (true)
        {
            Vector3 desiredPos = Triggers[columnIdx].transform.position + new Vector3(0, 3.05f, -4.525f);

            StartCoroutine(RotateCoin(counter));

            timeSinceStart += Time.deltaTime;
            Coins[counter].transform.position = Vector3.Lerp(Coins[counter].transform.position, desiredPos, timeSinceStart);

            if (Coins[counter].transform.position == desiredPos)
            {
                yield break;
            }
            yield return null;
        }
    }

    public IEnumerator RotateCoin(int counter)
    {
        float rotateSpeed = 0.02f;

        if (!PlayerHelper.isFirstPlayer)
        {
            angle = -90;
        }
        else
        {
            angle = 90;
        }

        Quaternion correctRotation = Quaternion.Euler(90, 90, angle);

        while (Coins[counter].transform.rotation != correctRotation)
        {
            Coins[counter].transform.rotation = Quaternion.Slerp(Coins[counter].transform.rotation, Quaternion.Euler(90, 90, angle), rotateSpeed * Time.time);

            yield return null;
        }

        Coins[counter].transform.rotation = correctRotation;
    }

    public IEnumerator ChangePlayer()
    {
        yield return new WaitForSeconds(3f);
        CameraRotate.helper += 1;
    }
}