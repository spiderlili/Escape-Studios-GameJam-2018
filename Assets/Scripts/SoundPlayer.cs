using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    [SerializeField] private float m_LowPitch = 0.95f;
    [SerializeField] private float m_HighPitch = 1.05f;

    private AudioSource m_Audio;

    public static SoundPlayer Instance { get; private set; }

    private void Awake()
    {
        //if (Instance == null)
        //{
            Instance = this;
          //  DontDestroyOnLoad(gameObject);
            m_Audio = GetComponent<AudioSource>();
        //}
    }

    public void Play(AudioClip clip)
    {
        if (clip == null) return;

        m_Audio.pitch = 1f;
        m_Audio.PlayOneShot(clip);
    }

    public void PlayRandom(params AudioClip[] clips)
    {
        if (clips.Length <= 0) return;

        AudioClip clipToPlay = clips[Random.Range(0, clips.Length)];
        m_Audio.pitch = Random.Range(m_LowPitch, m_HighPitch);

        m_Audio.PlayOneShot(clipToPlay);
    }

}
