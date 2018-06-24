using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public delegate void PlantEvent();
    public static event PlantEvent OnMonsterSprout;

    [SerializeField] private GameObject m_TreeMonsterPrefab;

    [SerializeField] private AudioClip m_PlantSound;

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
            OnMonsterSprout();
            m_SeedPlanted = false;
            Destroy(this);
        }
        else if (m_Activated)
        {
            if (TimeController.Instance.CurrentState == TimeState.PAST)
            {
                GetComponent<Interactable>().m_IsActive = true;
            }
            else
            {
                GetComponent<Interactable>().m_IsActive = false;
            }
        }
        
    }

    private void OnItemPickup(ItemType i)
    {
        if (i == ItemType.SEED)
        {
            m_Activated = true;
            if (TimeController.Instance.CurrentState == TimeState.PAST)
            {
                GetComponent<Interactable>().m_IsActive = true;
            }   
        }
    }

    public void PlantSeed()
    {
        SoundPlayer.Instance.Play(m_PlantSound);
        m_Animator.SetTrigger("plantTrigger");
        m_SeedPlanted = true;
        FindObjectOfType<Inventory>().Remove(ItemType.SEED);
        Destroy(GetComponent<Interactable>());
    }

    private void OnDisable()
    {
        Inventory.OnItemPickup -= OnItemPickup;
        TimeController.OnTimeSwap -= OnTimeSwap;
    }



}
