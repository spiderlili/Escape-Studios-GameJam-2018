using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private AudioClip m_PickupSound;

    public void OnPickup()
    {
        SoundPlayer.Instance.Play(m_PickupSound);
        FindObjectOfType<Inventory>().Pickup(ItemType.BOOK);
        Destroy(gameObject);
    }



}
