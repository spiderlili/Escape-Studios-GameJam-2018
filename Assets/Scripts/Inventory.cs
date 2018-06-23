using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // --------------------------------------------------------------

    public delegate void ItemEvent(ItemType i);
    public static event ItemEvent OnItemPickup;
    public static event ItemEvent OnItemDrop;

    // --------------------------------------------------------------

    [SerializeField]
    private GameObject m_GunPrefab;

    // --------------------------------------------------------------

    private HashSet<ItemType> m_Items = new HashSet<ItemType>();

    // --------------------------------------------------------------

    public bool Pickup(ItemType i)
    {
        if (m_Items.Contains(i)) return false;

        switch (i)
        {
            case ItemType.GUN:
                Instantiate(m_GunPrefab, transform);
                break;
        }

        m_Items.Add(i);
        OnItemPickup(i);
        return true;
    }

    public void Remove(ItemType i)
    {
        m_Items.Remove(i);
        OnItemDrop(i);
    }

    public bool HasItem(ItemType i)
    {
        return m_Items.Contains(i);
    }
}
