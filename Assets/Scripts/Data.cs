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

    public static int GetAmountCollected(PlantEntry plantEntry)
    {
        return PlayerPrefs.GetInt(GetPlantCollectedKey(plantEntry), 0);
    }

    public static int GetAmountCollected(PlantKind plantKind)
    {
        PlantEntry plantEntry = allPlants[plantKind];
        return GetAmountCollected(plantEntry);
    }
    
    public static Dictionary<PlantKind, int> LoadPlantInventory()
    {
        Dictionary<PlantKind, int> collectedPlants = new();

        foreach (KeyValuePair<PlantKind, PlantEntry> kvp in allPlants)
        {
            var plantKind = kvp.Key;
            var plantEntry = kvp.Value;

            var amountCollected = GetAmountCollected(plantEntry);

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

    public static bool PlantIsDiscovered(PlantEntry plantEntry)
    {
        return PlayerPrefs.HasKey(GetPlantDiscoveredKey(plantEntry));
    }

    public static bool PlantIsDiscovered(PlantKind plantKind)
    {
        PlantEntry plantEntry = allPlants[plantKind];
        return PlantIsDiscovered(plantEntry);
    }

    public static List<PlantKind> LoadPlantDiscovery()
    {
        List<PlantKind> plantKindsDiscovered = new();

        foreach (KeyValuePair<PlantKind, PlantEntry> kvp in allPlants)
        {
            var plantKind = kvp.Key;
            var plantEntry = kvp.Value;

            if (PlantIsDiscovered(plantEntry)) {
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
