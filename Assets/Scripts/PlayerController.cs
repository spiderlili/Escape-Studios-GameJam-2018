using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // --------------------------------------------------------------

    [SerializeField] private Camera m_Camera;

    [SerializeField] private float m_WalkSpeed;

    [SerializeField] private float m_GravityScale = 60f;

    [SerializeField] private float m_JumpHeight = 4f;

    // --------------------------------------------------------------

    private CharacterController m_CharController;

    private Vector3 m_MovementDirection;

    private Vector3 m_MovementOffset;

    private float m_VerticalSpeed;

    private Animator m_Anim;

    // --------------------------------------------------------------

    private void Awake()
    {
        m_CharController = GetComponent<CharacterController>();
        m_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateMovementDirection();

        m_MovementOffset = (m_MovementDirection * m_WalkSpeed + new Vector3(0, m_VerticalSpeed, 0)) * Time.deltaTime;

        m_CharController.Move(m_MovementOffset);

        transform.rotation = Quaternion.LookRotation(m_Camera.transform.forward);

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

        m_Anim.SetBool("isMoving", horizontalInput > 0 || verticalInput > 0);
        m_Anim.SetFloat("xMovement", horizontalInput);
        m_Anim.SetFloat("yMovement", verticalInput);

        m_MovementDirection = new Vector3(m_Camera.transform.forward.x, 0, m_Camera.transform.forward.z) * verticalInput +
                              new Vector3(m_Camera.transform.right.x, 0, m_Camera.transform.right.z) * horizontalInput;
    }



    private void ApplyGravity()
    {
        m_VerticalSpeed -= m_GravityScale * Time.deltaTime;
    }
}
