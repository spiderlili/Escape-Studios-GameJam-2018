using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int m_StartHealth = 3;

    private float m_CurrentHealth;

    private void Awake()
    {
        m_CurrentHealth = m_StartHealth;
    }

    public void TakeDamage()
    {
        Debug.Log("Player took damage!");
        m_CurrentHealth--;
        if (m_CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponentInChildren<Renderer>().enabled = false;
        FindObjectOfType<LevelRestarter>().OnGameOver();
        Debug.Log("Player died!");
    }
}
