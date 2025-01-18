using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicBehaviour : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textField;

    [SerializeField]
    private string text;

    [SerializeField]
    private Color defaultColor;

    [SerializeField]
    private Color hoveredColor;

    [SerializeField]
    private Color activedColor;

    private bool isHovered;

    private void Start()
    {
        textField.text = text;
        textField.color = defaultColor;

        isHovered = false;
    }

    public virtual void EnterHover()
    {
        textField.color = hoveredColor;

        isHovered = true;
    }

    public virtual void ExitHover()
    {
        textField.color = defaultColor;

        isHovered = false;
    }

    public virtual void EnterInteraction()
    {
        textField.color = activedColor;
    }

    public virtual void ExitInteraction()
    {
        textField.color = isHovered ? hoveredColor : defaultColor;
    }
}
