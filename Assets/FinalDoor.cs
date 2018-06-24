using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    [SerializeField]
    private Animator m_PanelAnim;

    [SerializeField]
    private GameObject m_ToDestroy;

    public void TheEnd()
    {
        GetComponent<Animator>().SetTrigger("openTrigger");
        GetComponent<Interactable>().m_IsActive = true;
    }

    public void FadeOut()
    {
        m_PanelAnim.SetTrigger("winTrigger");
        Destroy(m_ToDestroy);
    }
	
}
