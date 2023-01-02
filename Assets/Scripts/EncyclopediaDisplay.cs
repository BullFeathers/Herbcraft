using UnityEngine;
using System.Collections;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!
using TMPro;
using static Encyclopedia;
 
public class EncyclopediaDisplay : MonoBehaviour {

    public PlantKind plantKind;
    public TMP_Text plantCount;  // public if you want to drag your text object in there manually
    public TMP_Text description;
    int yarrowCounter;
 
    void Start () {
        //plantCount = GetComponent<TMP_Text>();  // if you want to reference it by code - tag it if you have several texts
    }
 
    void Update () {
        description.text = GetEntry(plantKind).info;
        plantCount.text = Data.GetAmountCollected(plantKind).ToString();  // make it a string to output to the Text object
    }
}