using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    [SerializeField]
    private Animator m_PanelAnim;

    [SerializeField]
    private GameObject m_ToDestroy;

    [SerializeField]
    private AudioClip m_FinalSound;

    public void TheEnd()
    {
        GetComponent<Animator>().SetTrigger("openTrigger");
        GetComponent<Interactable>().m_IsActive = true;
    }

    public void FadeOut()
    {
        SoundPlayer.Instance.Play(m_FinalSound);
        m_PanelAnim.SetTrigger("winTrigger");
        Destroy(m_ToDestroy);
    }
	
}
