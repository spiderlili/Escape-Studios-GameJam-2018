using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    [SerializeField] private GameObject m_SeedPrefab;
    [SerializeField] private GameObject m_CandyPrefab;

    [SerializeField] private Transform m_DropSpot;


    [SerializeField] private string m_EnabledDescription;
    [SerializeField] private string m_DisabledDescription;

    private Inventory m_Player;

    private Interactable m_Interact;

    private bool m_IsEnabled = false;

    private void Awake()
    {
        m_Player = FindObjectOfType<Inventory>();
        m_Interact = GetComponent<Interactable>();
        m_Interact.m_Description = m_DisabledDescription;

        Inventory.OnItemPickup += CheckForEnable;
        Inventory.OnItemDrop += CheckForEnable;
    }

    private void CheckForEnable(ItemType i)
    {
        if (i == ItemType.COIN)
        {
            m_IsEnabled = true;
            m_Interact.m_Description = m_EnabledDescription;
            m_Interact.m_PromptSize = TutorialType.BIG;
        }
    }

    private void CheckForDisable(ItemType i)
    {
        if (i == ItemType.COIN)
        {
            m_IsEnabled = false;
            m_Interact.m_Description = m_DisabledDescription;
            m_Interact.m_PromptSize = TutorialType.SMALL;
        }
    }

    public void Activate()
    {
        if (!m_IsEnabled) return;

        m_Player.Remove(ItemType.COIN);

        if (TimeController.Instance.CurrentState == TimeState.FUTURE)
        {
            Instantiate(m_SeedPrefab, m_DropSpot.position, Quaternion.identity);
            Destroy(m_Interact);
            OnDisable();
        }
        else
        {
            Instantiate(m_CandyPrefab, m_DropSpot.position, Quaternion.identity);
        }

        Destroy(GameObject.Find("Coin stack").GetComponent<Item>());
    }

    private void OnDisable()
    {
        Inventory.OnItemPickup -= CheckForEnable;
        Inventory.OnItemDrop -= CheckForEnable;
    }

}
