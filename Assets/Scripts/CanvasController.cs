using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public void ShowCanvas()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void HideCanvas()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
