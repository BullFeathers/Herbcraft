using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Encyclopedia;

public class PlantIcon : MonoBehaviour
{
    public Image iconImage;
    public Button iconButton;
    public PlantKind plantKind;

    private void Update()
    {
        if (Data.PlantKindIsDiscovered(plantKind))
        {
            // Light up the icon
            iconImage.color = Color.white;

            // Enable the button
            iconButton.interactable = true;
        }
    }
}
