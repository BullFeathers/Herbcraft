using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int plants = 0;
    public bool rose = false;
    [SerializeField] TextMeshProUGUI plantsText;
    [SerializeField] TextMeshProUGUI roseText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            Destroy (other.gameObject);
            plants++;
            plantsText.text = "Plants Collected :" + plants;
        }

        if (other.gameObject.CompareTag("Rose"))
        {
            Destroy (other.gameObject);
            rose = true;
            roseText.text = "You have unlocked Rose!";
        }
    }
}
