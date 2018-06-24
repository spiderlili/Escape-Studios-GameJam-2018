using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject m_TreeMonsterPrefab;

    private Animator m_Animator;

    private bool m_Activated = false;

    private bool m_SeedPlanted = false;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();

        Inventory.OnItemPickup += OnItemPickup;
        TimeController.OnTimeSwap += OnTimeSwap;
    }

    private void OnTimeSwap()
    {
        if (m_SeedPlanted)
        {
            Instantiate(m_TreeMonsterPrefab, transform.GetChild(0).position, Quaternion.identity);
            m_SeedPlanted = false;
            Destroy(this);
        }
    }

    private void OnItemPickup(ItemType i)
    {
        if (i == ItemType.SEED)
        {
            m_Activated = true;
            GetComponent<Interactable>().m_IsActive = true;
        }
    }

    public void PlantSeed()
    {
        m_Animator.SetTrigger("plantTrigger");
        m_SeedPlanted = true;
        Destroy(GetComponent<Interactable>());
    }

    private void OnDisable()
    {
        Inventory.OnItemPickup -= OnItemPickup;
    }



}
