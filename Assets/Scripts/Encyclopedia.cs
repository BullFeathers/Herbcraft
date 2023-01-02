using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class Encyclopedia : MonoBehaviour
{

    // A class to store information about a single plant
    [System.Serializable]
    public class Plant
    {
        public string name;
        public string info;
        public GameObject collider;
        public GameObject gameObject;
        public int amount;
    }

    // A dictionary to store the plants, using the name of the plant as the key
    Dictionary<string, Plant> plantDictionary = new Dictionary<string, Plant>();

    // An array to store information about all of the plants
    public Plant[] plants;


    void Start()
    {
        // Set up the colliders for each plant
        for (int i = 0; i < plants.Length; i++)
        {
            plantDictionary[plants[i].name] = plants[i];
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that was entered belongs to a plant
        foreach (KeyValuePair<string, Plant> plant in plantDictionary)
        {
            if (other == plant.Value.collider.GetComponent<Collider>())
            {
                if (Input.GetButtonDown("e"))
                {
                    // If the player has entered the collider, unlock the corresponding plant and display its information
                    UnlockPlant(plant.Value);
                    break;
                }
            }
        }
    }

    void UnlockPlant(Plant plant)
    {
        // Display the information for the unlocked plant
        Debug.Log(plant.info);

        // Set the plant GameObject to inactive
        plant.gameObject.SetActive(false);

        //Increment the amount of the object owned
        plant.amount++;
    }
}
