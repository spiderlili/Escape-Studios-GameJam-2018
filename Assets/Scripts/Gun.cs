using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // --------------------------------------------------------------

    [SerializeField] private GameObject m_Projectile;

    [SerializeField] private float m_SecsBetweenShots;

    // --------------------------------------------------------------

    private bool m_IsFiring = false;

    // --------------------------------------------------------------

    private void Update()
    {
        UpdateRotation();
        if (Input.GetAxisRaw("Fire3") > 0 && !m_IsFiring)
        {
            InvokeRepeating("Fire", 0.000001f, m_SecsBetweenShots);
            m_IsFiring = true;
        }
        if (Input.GetAxisRaw("Fire3") < Mathf.Epsilon)
        {
            CancelInvoke("Fire");
            m_IsFiring = false;
        }
    }

    private void Fire()
    {
        Instantiate(m_Projectile, transform.position, transform.rotation);
    }

    private void UpdateRotation()
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
