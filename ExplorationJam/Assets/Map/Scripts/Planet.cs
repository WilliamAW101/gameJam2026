using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] public float gravityStrength;
    [SerializeField] bool small;
    [SerializeField] bool medium;
    [SerializeField] bool large;
    [SerializeField] bool isEarth = false;
    public struct item
    {
        public int itemID;
        public int itemCost;
    }
    item[] items = new List<item>().ToArray();
    private int itemCount;
    [SerializeField] string planetName;

    enum PlanetNames
    {
        Zephyrus,
        Aetheria,
        Lumora,
        Nereidia,
        Solara,
        Terranova,
        Astralis,
        Vortexia,
        Celestara,
        Nebulon
    }

    void Awake()
    {
        planetName = getPlanetName();
        decideItemCount();
        Debug.Log("Planet " + planetName + " created with " + itemCount + " items.");
        decideItems();
    }

    void Start()
    {
        // printItems();
    }

    // randomly select a planet name from the enum
    private string getPlanetName()
    {
        int enumLength = PlanetNames.GetNames(typeof(PlanetNames)).Length;
        int randomIndex = Random.Range(0, enumLength);
        planetName = ((PlanetNames)randomIndex).ToString();
        return planetName;
    }

    private void decideItemCount()
    {
        if (!isEarth) {
            if (small)
            {
                itemCount = Random.Range(1, 2);
            }
            else if (medium)
            {
                itemCount = Random.Range(1, 3);
            }
            else if (large)
            {
                itemCount = Random.Range(1, 5);
            }  
        }

    }

    private void decideItems()
    {
        for (int i = 0; i < itemCount; i++)
        {
            items = items.Append(new item()).ToArray();
            items[i].itemID = Random.Range(0, 5);
            items[i].itemCost = Random.Range(1, 24);
        }
    }

    // debugging crap
    private void printItems()
    {
        for (int i = 0; i < itemCount; i++)
        {
            Debug.Log("Item ID: " + items[i].itemID + ", Item Cost: " + items[i].itemCost);
        }
    }

    public List<item> getItemList()
    {
        return items.ToList();
    }

    public int getItemCount()
    {
        return itemCount;
    }

    public string getSinglePlanetName()
    {
        return planetName;
    }

}