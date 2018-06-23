using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // --------------------------------------------------------------

    [SerializeField]
    private GameObject m_GunPrefab;

    // --------------------------------------------------------------

    private HashSet<ItemType> m_Items = new HashSet<ItemType>();

    // --------------------------------------------------------------

    public void Pickup(ItemType i)
    {
        Debug.Log("Picked up a " + i);

        switch (i)
        {
            case ItemType.GUN:
                Instantiate(m_GunPrefab, transform);
                break;
        }


        m_Items.Add(i);
    }

    public void Remove(ItemType i)
    {
        m_Items.Remove(i);
    }

    public bool HasItem(ItemType i)
    {
        return m_Items.Contains(i);
    }
}
