using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // --------------------------------------------------------------

    public delegate void TimeSwapEvent();

    public static event TimeSwapEvent OnTimeSwap;

    // --------------------------------------------------------------

    private TimeController m_Instance;

    // --------------------------------------------------------------

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnTimeSwap();
        }
    }

}
