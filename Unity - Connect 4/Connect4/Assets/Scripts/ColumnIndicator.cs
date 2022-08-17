using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnIndicator : MonoBehaviour
{
    public Transform arrow;
    public static bool collided;
    public static int column;

    public static Vector3 colliderPosition;

    private void Awake()
    {
        column = 0;
        collided = false;

        colliderPosition = this.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        collided = true;

        if (other.tag == "Coin")
        {
            column = System.Convert.ToInt32(this.tag);
            colliderPosition = this.transform.position + new Vector3(0, 3.05f, -4.55f);

            arrow.position = this.transform.position + new Vector3(0, 1.5f, -3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collided = false;

        if (other.tag == "Coin")
        {
            arrow.position = new Vector3(0, -3, 0);
        }
    }
}
