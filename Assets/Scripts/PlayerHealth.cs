using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int m_StartHealth = 3;

    [SerializeField] private float m_InvincibilityTime = 1f;

    private bool m_IsInvincible = false;

    private float m_CurrentHealth;

    private void Awake()
    {
        m_CurrentHealth = m_StartHealth;
    }

    public void TakeDamage()
    {
        if (m_IsInvincible) return;

        Debug.Log("Player took damage!");
        m_CurrentHealth--;
        if (m_CurrentHealth <= 0)
        {
            Die();
        }
        else
        {
            m_IsInvincible = true;
            Invoke("DeactivateInvincibility", m_InvincibilityTime);
        }
    }

    private void DeactivateInvincibility()
    {
        m_IsInvincible = false;
    }

    private void Die()
    {
        GetComponentInChildren<Renderer>().enabled = false;
        FindObjectOfType<LevelRestarter>().OnGameOver();
        Debug.Log("Player died!");
    }
}
