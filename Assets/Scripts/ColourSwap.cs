using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSwap : MonoBehaviour
{
    [SerializeField]
    private Color m_OldColour;

    [SerializeField]
    private Color m_NewColour;


    private Camera m_Camera;

    private void Awake()
    {
        m_Camera = GetComponent<Camera>();
        m_Camera.backgroundColor = m_OldColour;
    }

    private void Start()
    {
        TimeController.OnTimeSwap += OnChangeColour;    
    }

    private void OnChangeColour()
    {
        switch (TimeController.Instance.CurrentState)
        {
            case TimeState.PAST:
                m_Camera.backgroundColor = m_OldColour;
                break;
            case TimeState.FUTURE:
                m_Camera.backgroundColor = m_NewColour;
                break;
        }
    }

    private void OnDisable()
    {
        TimeController.OnTimeSwap -= OnChangeColour;
    }
}
