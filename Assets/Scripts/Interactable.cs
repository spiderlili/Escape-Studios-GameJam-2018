using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // --------------------------------------------------------------

    [Serializable]
    public class InteractEvent : UnityEvent { }

    // --------------------------------------------------------------

    [SerializeField]
    private InteractEvent OnInteracted;

    [SerializeField]
    private bool m_ActivateOnTouch = false;

    [SerializeField]
    private string m_Description;

    // --------------------------------------------------------------

    private void OnTriggerEnter(Collider other)
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
                OnInteracted.Invoke();
            }
        }   
    }

}
