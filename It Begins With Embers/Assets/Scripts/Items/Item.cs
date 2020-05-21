using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Item : MonoBehaviour
{
    //[System.Serializable]
    public enum ItemType {Stick, Vine};
    public ItemType m_itemType;
    private bool m_bIsInRange = false;

    PlayerControls controls;
    PlayerItems items = null;


    private void Awake()
    {
        controls = new PlayerControls();
        items = FindObjectOfType<PlayerItems>();
    }

    private void Update()
    {
        controls.Gameplay.Start.performed += ctx => PickupItem();
    }

    private void PickupItem()
    {
        if (m_bIsInRange)
        {
            switch (m_itemType)
            {
                case ItemType.Stick:
                    items.stickCount += 1;
                    this.gameObject.SetActive(false);
                    break;
                case ItemType.Vine:
                    items.vineCount += 1;
                    this.gameObject.SetActive(false);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            m_bIsInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_bIsInRange = false;
        }
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}
