using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    [SerializeField] public PlanetManager planetManager;
    [SerializeField] List<List<Planet.item>> allItems = new List<List<Planet.item>>();
    private GameObject[] planets;
    private int highestItemID = -1;
    private int mediumItemID = -1;
    private int lowestItemID = -1;
    

    void Awake()
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

        if (allItems.Count < 3)
        {
            Debug.LogError("Need at least 3 item lists");
            return;
        }

        int highest, medium, lowest = 0;
        
        highest = Random.Range(0, allItems.Count);
        medium = Random.Range(0, allItems.Count);
        while (highest == medium)
            medium = Random.Range(0, allItems.Count);
        lowest = Random.Range(0, allItems.Count);
        while (lowest == medium || lowest == highest)
            lowest = Random.Range(0, allItems.Count);

        int highestIndex = Random.Range(0, allItems[highest].Count);
        Planet.item item = allItems[highest][highestIndex];
        item.itemCost = 100;
        allItems[highest][highestIndex] = item;

        int mediumIndex = Random.Range(0, allItems[medium].Count);
        item = allItems[medium][mediumIndex];
        item.itemCost = 75;
        allItems[medium][mediumIndex] = item;

        int lowestIndex = Random.Range(0, allItems[lowest].Count);
        item = allItems[lowest][lowestIndex];
        item.itemCost = 20;
        allItems[lowest][lowestIndex] = item;

        highestItemID = allItems[highest][highestIndex].itemID;
        Debug.Log("Highest Item ID selected: " + highestItemID);
        mediumItemID = allItems[medium][mediumIndex].itemID;
        Debug.Log("Medium Item ID selected: " + mediumItemID);
        lowestItemID = allItems[lowest][lowestIndex].itemID;
        Debug.Log("Lowest Item ID selected: " + lowestItemID);

        if (allItems[highest].Count == 0 || allItems[medium].Count == 0 || allItems[lowest].Count == 0)
        {
            Debug.LogError("Selected item list is empty");
            return;
        }

        resourceTracker.Instance.setHighestItemID(highestItemID);
        resourceTracker.Instance.setMediumItemID(mediumItemID);
        resourceTracker.Instance.setLowestItemID(lowestItemID);

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
