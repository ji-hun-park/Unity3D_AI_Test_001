using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        
        if (collider.CompareTag("Box"))
        {
            Debug.Log("BOX!");
        }
        
        if (collider.CompareTag("NPC"))
        {
            Debug.Log("NPC!");
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            if (Input.GetKey(GameManager.Instance.interactKey))
            {
                Debug.Log("interact with box");
                UIManager.Instance.altUI.currentItemObject = other.gameObject.GetComponent<ItemObjects>().itemName;
                UIManager.Instance.UIList[0].gameObject.SetActive(true);
            }
        }
        
        if (other.gameObject.CompareTag("NPC"))
        {
            if (Input.GetKey(GameManager.Instance.interactKey))
            {
                Debug.Log("interact with npc");
                Time.timeScale = 0;
                UIManager.Instance.UIList[1].gameObject.SetActive(true);
            }
        }
    }
}
