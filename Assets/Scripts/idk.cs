using UnityEngine;
using System.Collections;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!
using TMPro;
 
public class ScoreCounter : MonoBehaviour {
 
    public TMP_Text yarrowAmt;  // public if you want to drag your text object in there manually
    int yarrowCounter;
 
    void Start () {
        yarrowAmt = GetComponent<TMP_Text>();  // if you want to reference it by code - tag it if you have several texts
    }
 
    void Update () {
        yarrowAmt.text = yarrowCounter.ToString();  // make it a string to output to the Text object
    }
}