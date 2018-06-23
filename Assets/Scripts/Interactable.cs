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
    protected string m_Description;

    // --------------------------------------------------------------

    protected void OnTriggerEnter(Collider other)
    {
        // TODO: Display following in UI:
        Debug.Log(m_Description);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            if (Input.GetButtonDown("Fire2") || m_ActivateOnTouch)
            {
                OnInteract.Invoke();
            }
        }   
    }

}
