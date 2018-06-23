using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ItemType { GUN, SEED, COIN, }

public class Item : Interactable
{
    // --------------------------------------------------------------

    [SerializeField]
    private ItemType m_Type;

    // --------------------------------------------------------------

    private void OnTriggerStay(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null)
        {
            if (m_ActivateOnTouch || Input.GetButtonDown("Fire2"))
            {
                inventory.Pickup(m_Type);
                Destroy(gameObject);
            }
        }
        
        
    }

}
