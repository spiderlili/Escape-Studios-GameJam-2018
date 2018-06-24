using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    private Animator m_Anim;

    private bool m_IsUnlocked = false;

    private Inventory m_PlayerInventory;

    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
        m_PlayerInventory = FindObjectOfType<Inventory>();
    }

    public void OnUnlock()
    {
        m_PlayerInventory.Remove(ItemType.KEY);
        m_Anim.SetTrigger("unlockTrigger");
        m_IsUnlocked = true;
        FindObjectOfType<Book>().GetComponent<Interactable>().m_IsActive = true;
        Destroy(GetComponent<Interactable>());
    }

}
