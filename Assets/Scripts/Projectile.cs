using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // --------------------------------------------------------------

    [SerializeField] private float m_Speed = 3f;

    // --------------------------------------------------------------

    private void Update()
    {
        transform.Translate(-Vector3.forward * m_Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
    }

}
