using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource m_PastSource;
    private AudioSource m_FutureSource;

    private void Awake()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        m_PastSource = audioSources[0];
        m_FutureSource = audioSources[1];

        TimeController.OnTimeSwap += OnTimeSwap;
    }

    private void OnTimeSwap()
    {
        if (TimeController.Instance.CurrentState == TimeState.FUTURE)
        {
            m_PastSource.volume = 0f;
            m_FutureSource.volume = 1f;
        }
        else
        {
            m_FutureSource.volume= 0f;
            m_PastSource.volume = 1f;
        }
    }
}
