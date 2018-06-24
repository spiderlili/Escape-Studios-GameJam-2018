using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TutorialType { SMALL, BIG }

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private Vector3 m_OffsetFromPlayer;

    [SerializeField] private float m_TutorialTime = 2f;

    private Transform m_Player;

    private Camera m_Camera;

    private Text m_BigText;
    private Text m_SmallText;

    private Text m_ActiveText;

    private bool m_TutorialActive = false;

    public static TutorialManager Instance { get; private set; }

    private void Awake()
    {
        //if (Instance == null)
        //{
            Instance = this;

            Text[] texts = GetComponentsInChildren<Text>();
            m_BigText = texts[0];
            m_SmallText = texts[1];

            m_Player = FindObjectOfType<PlayerController>().transform;
            m_Camera = Camera.main;
        //}
    }

    private void Update()
    {
        if (m_TutorialActive)
        {
            Vector3 offset = m_OffsetFromPlayer;
            if (m_Camera.WorldToViewportPoint(m_Player.position).x < 0.5f)
            {
                offset = new Vector3(-offset.x, offset.y, -offset.z);
            }
            m_ActiveText.transform.position = m_Camera.WorldToScreenPoint(m_Player.position + offset);
        }
    }

    public void QueueTutorial(string text, TutorialType type)
    {
        m_ActiveText = type == TutorialType.BIG ? m_BigText : m_SmallText;

        m_ActiveText.text = text;
        m_TutorialActive = true;

        m_ActiveText.GetComponent<Animator>().SetTrigger("showTrigger");
    }

}
