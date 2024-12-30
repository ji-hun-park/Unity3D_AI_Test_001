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
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("F");
            }
        }
    }
}
