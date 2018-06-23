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

    private bool m_FacingLeft = false;

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
        Instantiate(m_Projectile, transform.GetChild(0).position, transform.rotation);
    }

    private void UpdateRotation()
    {
        transform.rotation = Quaternion.LookRotation(transform.parent.right);
        if (Input.GetAxis("Horizontal") < 0 || m_FacingLeft)
        {
            m_FacingLeft = true;
            transform.Rotate(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            m_FacingLeft = false;
        }
    }
}
