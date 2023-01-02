using UnityEngine;
using UnityEngine.UI;

public class PlantIcon : MonoBehaviour
{
    public Image iconImage;
    public Button iconButton;

    void OnTriggerEnter(Collider other)
    {
            // Light up the icon
            iconImage.color = Color.white;

            // Enable the button
            iconButton.interactable = true;
    }
}
