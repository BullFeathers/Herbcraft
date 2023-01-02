using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Encyclopedia;

public class PlantCollection : MonoBehaviour
{

    private Plant collidedPlant;

    // A dictionary to store the plants, using the name of the plant as the key
    public List<PlantKind> discoveredPlants = new();
    public List<Plant> plantInventory = new();
    public Dictionary<PlantKind, int> collectedPlants = new();

    void LoadData()
    {
        collectedPlants = Data.LoadPlantInventory();
        discoveredPlants = Data.LoadPlantDiscovery();
    }

    // Update is called once per frame
    void Update()
    {
        if (collidedPlant != null && Input.GetButtonDown("Interact"))
        {
            // If the player has entered the collider, unlock the corresponding plant and display its information
            if (!discoveredPlants.Contains(collidedPlant.PlantKind))
            {
                DiscoverPlant(collidedPlant);
            }
            CollectPlant(collidedPlant);
        }

        // Delete save data - DONT KEEP
        if (Input.GetKeyDown("r"))
        {
            Data.DeleteSave();
            LoadData();
            Debug.Log("you deleted save data");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            collidedPlant = other.gameObject.GetComponent<Plant>();
        }
    }

    void DiscoverPlant(Plant plant)
    {
        PlantEntry plantEntry = allPlants[plant.PlantKind];

        // Display the information for the unlocked plant
        Debug.Log(plantEntry.info);

        discoveredPlants.Add(plant.PlantKind);

        Data.AddPlantDiscovery(plant.PlantKind);

    }

    void CollectPlant(Plant plant)
    {

        plantInventory.Add(plant);

        int amount;

        if (collectedPlants.ContainsKey(plant.PlantKind))
        {
            Debug.Log($"Collected plants contains {plant.name}.");
            amount = collectedPlants[plant.PlantKind] + plant.amount;
        }
        else
        {
            Debug.Log($"Collected plants does not yet contain {plant.name}.");
            // TODO: calculate bonus plants
            collectedPlants.Add(plant.PlantKind, plant.amount);
            amount = plant.amount;
        }

        collectedPlants[plant.PlantKind] = amount;

        Data.AddPlant(plant.PlantKind, amount);

        // TODO: remove plants that are not present

        // Set the plant GameObject to inactive
        plant.gameObject.SetActive(false);

        // Display the information for the unlocked plant
        Debug.Log(collectedPlants[plant.PlantKind]);

        collidedPlant = null;
    }

    private void Start()
    {
        LoadData();
    }

}
