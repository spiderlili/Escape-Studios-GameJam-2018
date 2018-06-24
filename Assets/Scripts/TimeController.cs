using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeState { PAST, FUTURE };

public class TimeController : MonoBehaviour
{
    // --------------------------------------------------------------

    [SerializeField] private Animator m_PanelAnim;

    // --------------------------------------------------------------

    public delegate void TimeSwapEvent();

    public static event TimeSwapEvent OnTimeSwap;

    // --------------------------------------------------------------

    [SerializeField]
    private AudioClip m_TimeWarpSound;

    [SerializeField]
    private float m_SwapTime = 0.5f;

    // --------------------------------------------------------------

    public static TimeController Instance { get; private set; }

    public TimeState CurrentState { get; private set; } = TimeState.PAST;

    // --------------------------------------------------------------

    private bool m_FirstSwapDone = false;

    private bool m_PerformingSwap = false;

    private float m_SwapStartTime;

    private float m_TimeRemaining;

    // --------------------------------------------------------------

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (m_PerformingSwap)
        {
            m_TimeRemaining -= Time.unscaledDeltaTime;
            if (m_TimeRemaining <= 0f)
            {
                PerformSwap();
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            m_PanelAnim.SetTrigger("swapTrigger");
            StartSwap();
        }
    }

    private void StartSwap()
    {
        SoundPlayer.Instance.Play(m_TimeWarpSound);
        m_PerformingSwap = true;
        m_TimeRemaining = m_SwapTime;
        Time.timeScale = 0.1f * Time.timeScale;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    private void PerformSwap()
    {
        m_PerformingSwap = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        CurrentState = CurrentState == TimeState.PAST ? TimeState.FUTURE : TimeState.PAST;
        OnTimeSwap();

        if (!m_FirstSwapDone)
        {
            m_FirstSwapDone = true;
            DialogueController.Instance.StartDialogue(DialogueEvent.FIRST_WARP);
        }
    }

}
