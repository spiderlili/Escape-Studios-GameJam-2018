using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TreeMonster : MonoBehaviour
{
    private NavMeshAgent m_Nav;

    private Camera m_Camera;

    private Transform m_Player;

    private Animator m_Anim;

    private void Awake()
    {
        m_Nav = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        m_Player = FindObjectOfType<PlayerController>().transform;
        m_Camera = Camera.main;
    }

    private void Update()
    {
        if (m_Nav.enabled)
        {
            transform.rotation = Quaternion.LookRotation(m_Camera.transform.forward);
            m_Nav.destination = m_Player.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage();
        }
    }


    public void Die()
    {
        m_Nav.enabled = false;
        m_Anim.SetTrigger("deathTrigger");
        Invoke("Death", 3f);
    }

    private void Death()
    {
        Destroy(gameObject);
    }


}
