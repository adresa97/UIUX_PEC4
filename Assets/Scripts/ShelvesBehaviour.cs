using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShelvesBehaviour : MonoBehaviour
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
    private Color testActived;

    private bool isHovered;

    private void Start()
    {
        textField.text = text;
        textField.color = defaultColor;

        isHovered = false;
    }

    public void EnterHover()
    {
        textField.color = hoveredColor;

        isHovered = true;
    }

    public void ExitHover()
    {
        textField.color = defaultColor;

        isHovered = false;
    }

    public void EnterInteraction()
    {
        textField.color = testActived;
    }

    public void ExitInteraction()
    {
        textField.color = isHovered ? hoveredColor : defaultColor;
    }
}
