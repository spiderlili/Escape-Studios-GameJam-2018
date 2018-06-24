using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{

    public void TheEnd()
    {
        GetComponent<Animator>().SetTrigger("openTrigger");
        GetComponent<Interactable>().m_IsActive = true;
    }

    public void FadeOut()
    {
        // TODO:

    }
	
}
