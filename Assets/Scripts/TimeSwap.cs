using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwap : MonoBehaviour
{
    // --------------------------------------------------------------

    private GameObject m_OldVersion;

    private GameObject m_NewVersion;

    // --------------------------------------------------------------

    private void Start()
    {
        m_OldVersion = transform.GetChild(0).gameObject;
        m_NewVersion = transform.GetChild(1).gameObject;

        switch (TimeController.Instance.CurrentState)
        {
            case TimeState.PAST:
                m_NewVersion.SetActive(false);
                m_OldVersion.SetActive(true);
                break;
            case TimeState.FUTURE:
                m_OldVersion.SetActive(false);
                m_NewVersion.SetActive(true);
                break;
        }

        TimeController.OnTimeSwap += OnSwapModels;

    }

    private void OnSwapModels()
    {
        m_NewVersion.SetActive(!m_NewVersion.activeInHierarchy);
        m_OldVersion.SetActive(!m_OldVersion.activeInHierarchy);
    }

    private void OnDisable()
    {
        TimeController.OnTimeSwap -= OnSwapModels;
    }
}
