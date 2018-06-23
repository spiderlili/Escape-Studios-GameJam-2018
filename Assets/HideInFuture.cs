using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInFuture : MonoBehaviour
{
    private void Awake()
    {
        TimeController.OnTimeSwap += OnTimeSwap;
    }

    private void OnTimeSwap()
    {
        bool visible = true;
        if (TimeController.Instance.CurrentState == TimeState.FUTURE)
        {
            visible = false;
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(visible);
        }

    }
}
