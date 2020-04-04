using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Interactable interactable;

    [SerializeField]
    private KeyCode interactKey;

    void Update()
    {
        if(interactable != null)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interactable.Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Triggered when in range of 2D trigger collider

        if (collision.CompareTag("Interactable"))
        {
            interactable = collision.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactable = null;
        }
    }
}
