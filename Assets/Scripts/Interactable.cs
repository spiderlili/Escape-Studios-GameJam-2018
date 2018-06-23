using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // --------------------------------------------------------------

    [SerializeField]
    protected UnityEvent OnInteract;

    [SerializeField]
    protected bool m_ActivateOnTouch = false;

    [SerializeField]
    public string m_Description;

    [SerializeField]
    public TutorialType m_PromptSize;

    // --------------------------------------------------------------

    protected void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            if (m_Description != "")
            {
                TutorialManager.Instance.QueueTutorial(m_Description, m_PromptSize);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            if (Input.GetButtonDown("Fire1") || m_ActivateOnTouch)
            {
                OnInteract.Invoke();
            }
        }   
    }

}
