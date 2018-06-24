using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Camera m_Camera;

    private Inventory m_Inventory;

    private void Awake()
    {
        m_Camera = Camera.main;
        m_Inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(m_Camera.transform.forward);
    }

    public void OnTalkedTo()
    {
        if (m_Inventory.HasItem(ItemType.BOOK))
        {
            DialogueController.Instance.StartDialogue(DialogueEvent.BOOK_TRANSLATE);
        }
        else
        {
            DialogueController.Instance.StartDialogue(DialogueEvent.ROBOT_TALK);
        }
    }

}
