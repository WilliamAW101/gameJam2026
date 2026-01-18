using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    [SerializeField] public itemManager itemmanager;
    [SerializeField] List<List<Planet.item>> allItems;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static Transitions Instance { get; private set; }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToCameraTransition(int planetIndex)
    {
        allItems = itemmanager.getAllItems();
        List<Planet.item> planetItem = allItems[planetIndex];

        foreach (Planet.item item in planetItem) {
            Debug.Log(item.itemCost);
            Debug.Log(item.itemID);
        }
    }
}
