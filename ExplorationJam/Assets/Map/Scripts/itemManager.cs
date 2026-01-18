using System;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    [SerializeField] public PlanetManager planetManager;
    [SerializeField] List<List<Planet.item>> allItems = new List<List<Planet.item>>();
    private GameObject[] planets;
    

    void Start()
    {
        if (planetManager == null)
        {
            Debug.LogError("PlanetManager instance is null!");
            return;
        }
        planets = planetManager.getPlanets();
        Debug.Log("Item Manager started, managing items for " + planets.Length + " planets.");
        Debug.Log("Total items across all planets: " + countAllItems());
        grabAllItems();
        ListAllItems();
    }

    private int countAllItems()
    {
        int totalItemCount = 0;
        foreach (GameObject planet in planets)
        {
            totalItemCount += planet.GetComponent<Planet>().getItemCount();
        }
        return totalItemCount;
    }

    private void grabAllItems()
    {
        int i = 0;
        foreach (GameObject planet in planets)
        {
            Planet planetScript = planet.GetComponent<Planet>();
            planetScript.setPlanetID(i++);
            allItems.Add(planetScript.getItemList());
        }

        int highest, medium, lowest = 0;
        
        highest = UnityEngine.Random.Range(0, allItems.Count);
        medium = UnityEngine.Random.Range(0, allItems.Count);
        while (highest == medium)
            medium = UnityEngine.Random.Range(0, allItems.Count);
        lowest = UnityEngine.Random.Range(0, allItems.Count);
        while (lowest == medium || lowest == highest)
            lowest = UnityEngine.Random.Range(0, allItems.Count);
        
    }

    public List<List<Planet.item>> getAllItems()
    {
        return allItems;
    }

    public void ListAllItems()
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            Debug.Log("Items for Planet " + (i + 1) + ": which is " + planets[i].GetComponent<Planet>().getSinglePlanetName());
            foreach (Planet.item item in allItems[i])
            {
                Debug.Log("Item ID: " + item.itemID + ", Item Cost: " + item.itemCost);
            }
        }
    }
}
