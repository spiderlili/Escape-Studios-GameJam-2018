using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TreeMonster : MonoBehaviour
{
    public delegate void MonsterEvent();
    public static event MonsterEvent OnMonsterDeath;

    [SerializeField] private GameObject m_KeyPrefab;

    private NavMeshAgent m_Nav;

    private Camera m_Camera;

    private Transform m_Player;

    private Animator m_Anim;

    private Renderer m_Rend;

    private Collider[] m_Colliders;

    private void Awake()
    {
        m_Nav = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        m_Player = FindObjectOfType<PlayerController>().transform;
        m_Camera = Camera.main;
        m_Rend = GetComponentInChildren<Renderer>();
        m_Colliders = GetComponentsInChildren<Collider>();

        TimeController.OnTimeSwap += OnFreeze;
    }

    private void OnFreeze()
    {
        bool isEnabled = false;

        if (TimeController.Instance.CurrentState == TimeState.FUTURE)
        {
            isEnabled = true;
        }

        m_Rend.enabled = isEnabled;
        m_Nav.enabled = isEnabled;
        foreach (Collider col in m_Colliders)
        {
            col.enabled = isEnabled;
        }
    }

    private void Update()
    {
        if (m_Nav.enabled)
        {
            transform.rotation = Quaternion.LookRotation(m_Camera.transform.forward);
            m_Nav.destination = m_Player.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage();
        }
    }


    public void Die()
    {
        DialogueController.Instance.StartDialogue(DialogueEvent.MONSTER_KILL);
        m_Nav.enabled = false;
        m_Anim.SetTrigger("deathTrigger");
        Invoke("Death", 3f);
    }

    private void Death()
    {
        OnMonsterDeath();
        Instantiate(m_KeyPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        FindObjectOfType<Inventory>().Remove(ItemType.GUN);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        TimeController.OnTimeSwap -= OnFreeze;
    }

}
