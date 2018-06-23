using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private Sprite m_GunSprite;
    [SerializeField] private Sprite m_SeedSprite;
    [SerializeField] private Sprite m_CoinSprite;
    [SerializeField] private Sprite m_BookSprite;

    private Image[] m_ImageSlots;

    private Inventory m_Inventory;

    private void Awake()
    {
        m_Inventory = FindObjectOfType<Inventory>();

        m_ImageSlots = new Image[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            m_ImageSlots[i] = transform.GetChild(i).GetComponent<Image>();
        }

        Inventory.OnItemPickup += OnItemChange;
        Inventory.OnItemDrop += OnItemChange;
    }

    private void OnItemChange(ItemType item)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i >= m_Inventory.m_Items.Count)
            {
                m_ImageSlots[i].enabled = false;
                continue;
            }

            switch(m_Inventory.m_Items[i])
            {
                case ItemType.COIN:
                    m_ImageSlots[i].sprite = m_CoinSprite;
                    break;
                case ItemType.GUN:
                    m_ImageSlots[i].sprite = m_GunSprite;
                    break;
                case ItemType.SEED:
                    m_ImageSlots[i].sprite = m_SeedSprite;
                    break;
                case ItemType.BOOK:
                    m_ImageSlots[i].sprite = m_BookSprite;
                    break;

            }
            m_ImageSlots[i].enabled = true;
        }
    }

    private void OnDisable()
    {
        Inventory.OnItemPickup -= OnItemChange;
        Inventory.OnItemDrop -= OnItemChange;
    }
}
