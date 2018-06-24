using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    private bool m_Opened = false;

    public void Open()
    {
        if (!m_Opened)
        {
            GetComponent<Animator>().SetTrigger("openTrigger");
            Destroy(GetComponent<Interactable>());
        }
    }

}
