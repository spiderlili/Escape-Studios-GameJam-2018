using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    private void Update()
    {
        float cos = Input.GetAxis("RightHorizontal");
        float sin = Input.GetAxis("RightVertical");

        if (sin == 0f && cos == 0f)
        {
            return;
        }

        float rotationAngle = Mathf.Atan2(cos, sin) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotationAngle, transform.eulerAngles.z);
    }
}
