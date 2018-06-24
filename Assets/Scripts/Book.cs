using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    
    public void OnPickup()
    {
        FindObjectOfType<Inventory>().Pickup(ItemType.BOOK);
        Destroy(gameObject);
    }

}
