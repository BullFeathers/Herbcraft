using System.Collections.Generic;
using UnityEngine;

public class Encyclopedia : MonoBehaviour
{
    public enum PlantKind { Yarrow, Fern, Dandelion, Rose };

    // A class to store information about a single plant
    public class PlantEntry
    {
        public string name;
        public string info;
    }

    // A dictionary to store information about all of the plants
    public static Dictionary<PlantKind, PlantEntry> allPlants = new()
    {
        { PlantKind.Yarrow, new PlantEntry() { name = "Yarrow", info = "This is yarrow." } },
        { PlantKind.Fern, new PlantEntry() { name = "Fern", info = "This is fern." } },
        { PlantKind.Dandelion, new PlantEntry() { name = "Dandelion", info = "This is dandelion." } },
        { PlantKind.Rose, new PlantEntry() { name = "Rose", info = "This is rose." } }
    };

    public static PlantEntry GetEntry(PlantKind plantKind)
    {
        return allPlants[plantKind];
    }
}
