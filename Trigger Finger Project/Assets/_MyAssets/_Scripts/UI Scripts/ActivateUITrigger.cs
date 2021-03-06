using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivateUITrigger : MonoBehaviour
{
    [Header("UI References")]
    public Image Image;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Text2;

    [Header("Other References")]
    public GameObject TriggerToActivate;
    public FirstPersonController PlayerController;
    public PlayerInteractionController PlayerInteraction;

    private void OnTriggerEnter(Collider other)
    {
        StartUITrigger(other);
    }

    private void OnTriggerStay(Collider other) 
    {
        if (gameObject.name == "Aim Trigger Object") // For aiming tutorial
        {
            if (PlayerController != null && PlayerController.IsAiming)
            {
                Image.gameObject.SetActive(false);
                Text.gameObject.SetActive(false);
                Text2.gameObject.SetActive(true);
            }
            else
            {
                Image.gameObject.SetActive(true);
                Text.gameObject.SetActive(true);
                Text2.gameObject.SetActive(false);
            }
        }

        if (PlayerInteraction != null && PlayerInteraction.isAbleToInteract) // Turn off Look tutorial when looking at first Door Access
        {
            Debug.Log("15 works");
            EndUITrigger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EndUITrigger();
    }

    void StartUITrigger(Collider other)
    {
        if (other.gameObject.layer != 9)
        {
            
            if (Image != null)
            {
                Image.gameObject.SetActive(true);
            }

            if (Text != null)
            {
                Text.gameObject.SetActive(true);
            }

            if (TriggerToActivate != null)
            {
                TriggerToActivate.SetActive(true);
            }

        }
    }

    void EndUITrigger()
    {
        if (Image != null)
        {
            Image.gameObject.SetActive(false);
        }

        if (Text != null)
        {
            Text.gameObject.SetActive(false);
        }

        if (Text2 != null)
        {
            Text2.gameObject.SetActive(false);
        }

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EndUITrigger();
    }

    
}
