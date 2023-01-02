using System.Collections.Generic;
using UnityEngine;
using static Encyclopedia;

public class Data : MonoBehaviour
{
    public static string GetPlantCollectedKey(PlantEntry plantEntry)
    {
        return $"Collected:{plantEntry.name}";
    }

    public static string GetPlantDiscoveredKey(PlantEntry plantEntry)
    {
        return $"Discovered:{plantEntry.name}";
    }

    public static void AddPlant(PlantKind plantKind, int amount)
    {
        PlantEntry plantEntry = allPlants[plantKind];
        PlayerPrefs.SetInt(GetPlantCollectedKey(plantEntry), amount);
        PlayerPrefs.Save();
    }
    
    public static Dictionary<PlantKind, int> LoadPlantInventory()
    {
        Dictionary<PlantKind, int> collectedPlants = new();

        foreach (KeyValuePair<PlantKind, PlantEntry> kvp in allPlants)
        {
            var plantKind = kvp.Key;
            var plantEntry = kvp.Value;

            var amountCollected = PlayerPrefs.GetInt(GetPlantCollectedKey(plantEntry), 0);

            collectedPlants.Add(plantKind, amountCollected);
        }

        return collectedPlants;
    }

    /// Use this method when the player discovers a new plant param name="plantKind"!
    public static void AddPlantDiscovery(PlantKind plantKind)
    {
        PlantEntry plantEntry = allPlants[plantKind];
        PlayerPrefs.SetString(GetPlantDiscoveredKey(plantEntry), "yes");
        PlayerPrefs.Save();
    }

    public static bool PlantEntryIsDiscovered(PlantEntry plantEntry)
    {
        return PlayerPrefs.HasKey(GetPlantDiscoveredKey(plantEntry));
    }

    public static bool PlantKindIsDiscovered(PlantKind plantKind)
    {
        PlantEntry plantEntry = allPlants[plantKind];
        return PlantEntryIsDiscovered(plantEntry);
    }

    public static List<PlantKind> LoadPlantDiscovery()
    {
        List<PlantKind> plantKindsDiscovered = new();

        foreach (KeyValuePair<PlantKind, PlantEntry> kvp in allPlants)
        {
            var plantKind = kvp.Key;
            var plantEntry = kvp.Value;

            if (PlantEntryIsDiscovered(plantEntry)) {
                plantKindsDiscovered.Add(plantKind);
            }
        }

        return plantKindsDiscovered;
    }
    
    public static void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
