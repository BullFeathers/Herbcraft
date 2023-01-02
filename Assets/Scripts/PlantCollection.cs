using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Encyclopedia;

public class PlantCollection : MonoBehaviour
{
    
    private Plant collidedPlant;

    // A dictionary to store the plants, using the name of the plant as the key
    Dictionary<string, Plant> discoveredPlants = new();

    // Update is called once per frame
    void Update()
    {
        //&& Input.GetButtonDown("Interact") <- put down there V
        if (collidedPlant != null)
        {
            Debug.Log("plant isn't null");
            // If the player has entered the collider, unlock the corresponding plant and display its information
            UnlockPlant(collidedPlant);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("we collided");
        if (other.gameObject.CompareTag("Plant"))
        {
            Debug.Log("plant is plant");
            collidedPlant = other.gameObject.GetComponent<Plant>();
        }
    }

    void UnlockPlant(Plant plant)
    {
        PlantEntry plantEntry = allPlants[plant.PlantKind];

        // Display the information for the unlocked plant
        Debug.Log(plantEntry.name);
        Debug.Log(plantEntry.info);

        // Set the plant GameObject to inactive
        plant.gameObject.SetActive(false);

        //Increment the amount of the object owned
        plant.amount++;
    }
}
