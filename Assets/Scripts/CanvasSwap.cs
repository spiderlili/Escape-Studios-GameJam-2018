using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwap : MonoBehaviour
{

    private GameObject m_PastPanel;
    private GameObject m_FuturePanel;

    private void Awake()
    {
        m_PastPanel = transform.GetChild(0).gameObject;
        m_FuturePanel = transform.GetChild(1).gameObject;

        TimeController.OnTimeSwap += OnTimeSwap;

    }

    private void OnTimeSwap()
    {
        if (TimeController.Instance.CurrentState == TimeState.PAST)
        {
            m_FuturePanel.SetActive(false);
            m_PastPanel.SetActive(true);
        }
        else
        {
            m_FuturePanel.SetActive(true);
            m_PastPanel.SetActive(false);
        }
    }

    private void OnDisable()
    {
        TimeController.OnTimeSwap -= OnTimeSwap;
    }
}
