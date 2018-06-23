using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // --------------------------------------------------------------

    [SerializeField] private float m_WalkSpeed;

    [SerializeField] private float m_GravityScale = 60f;

    [SerializeField] private float m_JumpHeight = 4f;

    // --------------------------------------------------------------

    private CharacterController m_CharController;

    private Vector3 m_MovementDirection;

    private Vector3 m_MovementOffset;

    private float m_VerticalSpeed;

    // --------------------------------------------------------------

    private void Awake()
    {
        m_CharController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        UpdateMovementDirection();

        m_MovementOffset = (m_MovementDirection * m_WalkSpeed + new Vector3(0, m_VerticalSpeed, 0)) * Time.deltaTime;

        m_CharController.Move(m_MovementOffset);

        if (Input.GetButtonDown("Jump") && m_CharController.isGrounded)
        {
            m_VerticalSpeed = Mathf.Sqrt(m_JumpHeight * m_GravityScale);
        }

        ApplyGravity();
    }

    private void UpdateMovementDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        m_MovementDirection = new Vector3(horizontalInput, 0, verticalInput);
    }

    private void ApplyGravity()
    {
        m_VerticalSpeed -= m_GravityScale * Time.deltaTime;
    }
}
