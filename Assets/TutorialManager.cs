using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private Vector3 m_OffsetFromPlayer;

    [SerializeField] private float m_TutorialTime = 2f;

    private Transform m_Player;

    private Camera m_Camera;

    private Text m_Text;

    private Animator m_TextAnim;

    public TutorialManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            m_Text = GetComponentInChildren<Text>();
            m_TextAnim = m_Text.GetComponent<Animator>();
            m_Player = FindObjectOfType<PlayerController>().transform;
            m_Camera = Camera.main;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void QueueTutorial(string text)
    {
        m_Text.text = text;

        Vector3 offset = (m_Camera.WorldToViewportPoint(m_Player.position).x < 0.5f) ? m_OffsetFromPlayer : -m_OffsetFromPlayer;
        transform.position = m_Camera.WorldToScreenPoint(m_Player.position + offset);

        m_TextAnim.SetBool("isVisible", true);
        Invoke("HideTutorial", m_TutorialTime);
    }

    private void HideTutorial()
    {
        m_TextAnim.SetBool("isVisible", false);
    }

}
