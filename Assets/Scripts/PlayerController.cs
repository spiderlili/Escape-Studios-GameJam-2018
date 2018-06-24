using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // --------------------------------------------------------------

    [SerializeField] private Camera m_Camera;

    [SerializeField] private float m_WalkSpeed = 2f;

    [SerializeField] private float m_RunSpeed = 5f;

    [SerializeField] private float m_GravityScale = 60f;

    [SerializeField] private float m_JumpHeight = 4f;

    // --------------------------------------------------------------

    private float m_MovementSpeed;

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
        m_MovementSpeed = m_WalkSpeed;

        Plant.OnMonsterSprout += OnSpeedUp;
        TreeMonster.OnMonsterDeath += OnSlowDown;
    }

    private void OnSlowDown()
    {
        m_MovementSpeed = m_WalkSpeed;
    }

    private void OnSpeedUp()
    {
        m_MovementSpeed = m_RunSpeed;
    }

    private void Update()
    {
        UpdateMovementDirection();

        m_MovementOffset = (m_MovementDirection * m_MovementSpeed + new Vector3(0, m_VerticalSpeed, 0)) * Time.deltaTime;

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

        m_Anim.SetBool("isMoving", Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0);
        m_Anim.SetFloat("xMovement", horizontalInput);
        m_Anim.SetFloat("yMovement", verticalInput);

        m_MovementDirection = new Vector3(m_Camera.transform.forward.x, 0, m_Camera.transform.forward.z) * verticalInput +
                              new Vector3(m_Camera.transform.right.x, 0, m_Camera.transform.right.z) * horizontalInput;
    }



    private void ApplyGravity()
    {
        m_VerticalSpeed -= m_GravityScale * Time.deltaTime;
    }

    private void OnDisable()
    {
        Plant.OnMonsterSprout -= OnSpeedUp;
        TreeMonster.OnMonsterDeath -= OnSlowDown;
    }

}
