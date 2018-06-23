using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeState { PAST, FUTURE };

public class TimeController : MonoBehaviour
{
    // --------------------------------------------------------------

    public delegate void TimeSwapEvent();

    public static event TimeSwapEvent OnTimeSwap;

    // --------------------------------------------------------------

    [SerializeField]
    private AudioClip m_TimeWarpSound;

    // --------------------------------------------------------------

    public static TimeController Instance { get; private set; }

    public TimeState CurrentState { get; private set; } = TimeState.PAST;

    // --------------------------------------------------------------

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            CurrentState = CurrentState == TimeState.PAST ? TimeState.FUTURE : TimeState.PAST;
            SoundPlayer.Instance.Play(m_TimeWarpSound);
            OnTimeSwap();
        }
    }

}
