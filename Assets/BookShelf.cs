using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    private Animator m_Anim;

    private bool m_IsUnlocked = false;

    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
    }

    public void OnUnlock()
    {
        m_Anim.SetTrigger("unlockTrigger");
        m_IsUnlocked = true;
        Destroy(GetComponent<Interactable>());
    }

}
