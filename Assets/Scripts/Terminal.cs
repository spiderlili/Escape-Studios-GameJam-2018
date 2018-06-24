using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Terminal : MonoBehaviour
{
    [SerializeField]
    private Sprite m_PasswordScreen;

    [SerializeField]
    private Sprite m_BlankScreen;

    [SerializeField]
    private AudioClip[] m_SuccessSounds;

    [SerializeField]
    private AudioClip[] m_FailureSounds;

    [SerializeField]
    private Text m_TerminalMsg;

    [SerializeField]
    private FinalDoor m_FinalDoor;

    private PlayerController m_Player;

    private Image m_Screen;

    private InputField m_Input;

    private void Start()
    {
        m_Input = GetComponentInChildren<InputField>();
        m_Player = FindObjectOfType<PlayerController>();
        m_Screen = GetComponent<Image>();

        SetTerminalActive(false);
    }

    public void Activate()
    {
        m_Screen.sprite = m_PasswordScreen;
        SetTerminalActive(true);
        m_Input.interactable = true;
        EventSystem.current.SetSelectedGameObject(m_Input.gameObject);
    }

    private void SetTerminalActive(bool active)
    {
        m_Input.enabled = active;
        m_Input.GetComponent<Image>().enabled = active;
        m_Screen.enabled = active;
        m_Player.SetMovementActive(!active);
    }

    private void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            Cancel();
        }
    }

    public void OnType()
    {
        if (m_Input.text.Length > 3)
        {
            Submit();
        } 
    }

    private void Submit()
    {
        m_Screen.sprite = m_BlankScreen;
        m_Input.enabled = false;
        m_Input.GetComponent<Image>().enabled = false;
        m_TerminalMsg.enabled = true;
        if (m_Input.text == "0451")
        {
            m_Input.text = "";
            SoundPlayer.Instance.PlayRandom(m_SuccessSounds);
            StartCoroutine(FinalMessage(0));
        }
        else
        {
            m_Input.text = "";
            SoundPlayer.Instance.PlayRandom(m_FailureSounds);
            m_TerminalMsg.text = "INCORRECT PASSWORD\nPLEASE TRY AGAIN";
            DialogueController.Instance.StartDialogue(DialogueEvent.INCORRECT_CODE);
            Invoke("Cancel", 2f);
        }
    }

    private void Cancel()
    {
        m_Input.text = m_TerminalMsg.text = "";
        m_TerminalMsg.enabled = false;
        SetTerminalActive(false);
    }


    private IEnumerator FinalMessage(int index)
    {
        switch(index)
        {
            case 0:
                m_TerminalMsg.text = "WELL DONE, [ALEX]!";
                break;
            case 1:
                m_TerminalMsg.text = "YOU HAVE PASSED YOUR INTERVIEW!";
                break;
            case 2:
                m_TerminalMsg.text = "PLEASE EXIT THROUGH THE DOOR...";
                break;
            case 3:
                m_TerminalMsg.text = "WELCOME TO THE WORLD OF THE FUTURE!";
                break;
        }
        yield return null;
        while (!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        if (index < 3)
        {
            StartCoroutine(FinalMessage(index + 1));
        }
        else
        {
            m_FinalDoor.TheEnd();
            SetTerminalActive(false);
            Destroy(this);
        }
    }



}
