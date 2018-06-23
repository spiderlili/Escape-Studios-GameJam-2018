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
    private string Description;

    // --------------------------------------------------------------

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                OnInteracted.Invoke();
            }
        }   
    }

}
