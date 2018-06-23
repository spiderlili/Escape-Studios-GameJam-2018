using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Camera m_Camera;

    private void Awake()
    {
        m_Camera = Camera.main;
    }


    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(m_Camera.transform.forward);
    }

}
