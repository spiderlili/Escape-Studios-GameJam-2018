using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    private Animator m_Anim;

    private bool m_IsActivated = false;

    private bool m_IsUnlocked = false;

    private Interactable m_Interact;

    private Inventory m_PlayerInventory;

    private void Awake()
    {
        m_Anim = GetComponentInChildren<Animator>();
        m_PlayerInventory = FindObjectOfType<Inventory>();
        m_Interact = GetComponentInChildren<Interactable>();

        TimeController.OnTimeSwap += OnTimeSwap;
    }

    private void OnTimeSwap()
    {
        if (!m_IsActivated) return;

        if (TimeController.Instance.CurrentState == TimeState.PAST)
        {
            m_Interact.m_IsActive = true;
        }

    }

    public void Activate()
    {
        m_IsActivated = true;
        if (TimeController.Instance.CurrentState == TimeState.PAST)
        {
            GetComponentInChildren<Interactable>().m_IsActive = true;
        }
    }

    public void OnUnlock()
    {
        m_PlayerInventory.Remove(ItemType.KEY);
        m_Anim.SetTrigger("unlockTrigger");
        m_IsUnlocked = true;
        FindObjectOfType<Book>().GetComponent<Interactable>().m_IsActive = true;
        Destroy(m_Interact);
    }

}
