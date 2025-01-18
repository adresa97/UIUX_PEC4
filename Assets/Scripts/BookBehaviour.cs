using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookBehaviour : MonoBehaviour
{
    [SerializeField]
    private XRGrabInteractable interactable;

    [SerializeField]
    private Transform shelfPosition;

    [SerializeField]
    private Transform flyingPosition;

    [SerializeField]
    private Transform standPosition;

    [SerializeField]
    private Renderer bookRenderer;

    [SerializeField]
    private Color hoverColor;
    private Color defaultColor;

    [SerializeField]
    private Rigidbody rb;

    private bool isHovered;
    private bool isOnStand;
    private bool isOnShelf;

    private void Start()
    {
        SetToShelfPosition();
    }

    public void OnHoveredEnter()
    {
        bookRenderer.material.color = hoverColor;
        isHovered = true;
    }

    public void OnHoveredExit()
    {
        bookRenderer.material.color = defaultColor;
        isHovered = false;
    }

    public void OnSelectionEnter()
    {
        rb.isKinematic = false;
    }

    public void OnSelectionExit()
    {
        rb.isKinematic = true;

        if (isOnStand) SetToStandPosition();
        else
        {
            transform.position = flyingPosition.position;
            transform.rotation = flyingPosition.rotation;

            if (isHovered) bookRenderer.material.color = hoverColor;
            else bookRenderer.material.color = defaultColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stand")) isOnStand = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Stand")) isOnStand = false;
    }

    private void SetToStandPosition()
    {
        transform.position = standPosition.position;
        transform.rotation = standPosition.rotation;
    }

    public void SetToFlyingPosition()
    {
        if (isOnShelf)
        {
            transform.position = flyingPosition.position;
            transform.rotation = flyingPosition.rotation;

            bookRenderer.material.color = defaultColor;
            isHovered = false;
            isOnShelf = false;

            interactable.enabled = true;
        }
    }

    public void SetToShelfPosition()
    {
        rb.isKinematic = true;

        transform.position = shelfPosition.position;
        transform.rotation = shelfPosition.rotation;

        bookRenderer.material.color = defaultColor;
        isHovered = false;
        isOnStand = false;
        isOnShelf = true;

        interactable.enabled = false;
    }
}
