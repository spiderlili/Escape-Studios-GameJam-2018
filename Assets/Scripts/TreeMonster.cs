﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TreeMonster : MonoBehaviour
{

    private NavMeshAgent m_Nav;

    private Camera m_Camera;

    private Transform m_Player;

    private void Awake()
    {
        m_Nav = GetComponent<NavMeshAgent>();
        m_Player = FindObjectOfType<PlayerController>().transform;
        m_Camera = Camera.main;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(m_Camera.transform.forward);
        m_Nav.destination = m_Player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage();
        }
    }


}
