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


    // --------------------------------------------------------------

    public List<ItemType> m_Items = new List<ItemType>();

    // --------------------------------------------------------------

    public bool Pickup(ItemType i)
    {
        if (m_Items.Contains(i)) return false;

        switch (i)
        {
            case ItemType.GUN:
                transform.GetChild(2).gameObject.SetActive(true);
                break;
            case ItemType.KEY:
                FindObjectOfType<BookShelf>().Activate();
                break;

        }

        m_Items.Add(i);
        OnItemPickup(i);
        return true;
    }

    public void Remove(ItemType i)
    {
        m_Items.Remove(i);

        if (i == ItemType.GUN)
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }

        OnItemDrop(i);
    }

    public bool HasItem(ItemType i)
    {
        return m_Items.Contains(i);
    }
}
