using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // --------------------------------------------------------------

    private enum Direction { LEFT, RIGHT, FORWARD, BACK }

    // --------------------------------------------------------------

    [SerializeField] private GameObject m_Projectile;

    [SerializeField] private float m_SecsBetweenShots;

    [SerializeField] private AudioClip[] m_FireShots;

    // --------------------------------------------------------------

    private Direction m_AimDir = Direction.RIGHT;

    // --------------------------------------------------------------

    private void Update()
    {
        UpdateRotation();
        if (Input.GetButtonDown("Fire3"))
        {
            InvokeRepeating("Fire", 0.000001f, m_SecsBetweenShots);
        }
        if (Input.GetButtonUp("Fire3"))
        {
            CancelInvoke("Fire");
        }
    }

    private void Fire()
    {
        Instantiate(m_Projectile, transform.GetChild(0).position, transform.rotation);
        SoundPlayer.Instance.PlayRandom(m_FireShots);
    }

    private void UpdateRotation()
    {
        transform.rotation = Quaternion.LookRotation(transform.parent.right);
        if (Input.GetAxis("Horizontal") < 0 || m_AimDir == Direction.LEFT)
        {
            m_AimDir = Direction.LEFT;
            transform.Rotate(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") > 0 || m_AimDir == Direction.RIGHT)
        {
            m_AimDir = Direction.RIGHT;
        }
        if (Input.GetAxis("Vertical") < 0 || m_AimDir == Direction.BACK)
        {
            m_AimDir = Direction.BACK;
            transform.Rotate(0f, 90, 0f);
        }
        if (Input.GetAxis("Vertical") > 0 || m_AimDir == Direction.FORWARD)
        {
            m_AimDir = Direction.FORWARD;
            transform.Rotate(0f, -90f, 0f);
        }
    }
}
