using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap : MonoBehaviour
{
    [SerializeField]
    private Material m_PastMaterial;

    [SerializeField]
    private Material m_FutureMaterial;

    private Renderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<Renderer>();

        TimeController.OnTimeSwap += OnTimeSwap;

    }

    private void OnTimeSwap()
    {
        if (TimeController.Instance.CurrentState == TimeState.FUTURE)
        {
            m_Renderer.material = m_FutureMaterial;
        }
        else
        {
            m_Renderer.material = m_PastMaterial;
        }
    }

    private void OnDisable()
    {
        TimeController.OnTimeSwap -= OnTimeSwap;
    }

}
