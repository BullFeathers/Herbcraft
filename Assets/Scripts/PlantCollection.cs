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

    // Update is called once per frame
    void Update()
    {
        if (collidedPlant != null && Input.GetButtonDown("Interact"))
        {
            // If the player has entered the collider, unlock the corresponding plant and display its information
            if (!discoveredPlants.Contains(collidedPlant.PlantKind))
            {
                Debug.Log("not discovered plant");
                UnlockPlant(collidedPlant);
            }
            CollectPlant(collidedPlant);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            collidedPlant = other.gameObject.GetComponent<Plant>();
        }
    }

    void UnlockPlant(Plant plant)
    {
        PlantEntry plantEntry = allPlants[plant.PlantKind];

        // Display the information for the unlocked plant
        Debug.Log(plantEntry.info);
        Debug.Log("You unlocked it!");

        discoveredPlants.Add(plant.PlantKind);
    }

    void CollectPlant(Plant plant)
    {
        plantInventory.Add(plant);

        if (collectedPlants.ContainsKey(plant.PlantKind))
        {
            collectedPlants[plant.PlantKind] = collectedPlants[plant.PlantKind] + plant.amount;
        }
        else
        {
            // TODO: calculate bonus plants
            collectedPlants.Add(plant.PlantKind, plant.amount);
        }

        // Set the plant GameObject to inactive
        plant.gameObject.SetActive(false);

        // Display the information for the unlocked plant
        Debug.Log(collectedPlants[plant.PlantKind]);

        collidedPlant = null;
    }
}
