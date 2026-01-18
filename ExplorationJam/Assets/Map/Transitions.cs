using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public static Transitions Instance { get; private set; }
    [SerializeField] public itemManager itemmanager;
    [SerializeField] List<List<Planet.item>> allItems;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToCameraTransition(int planetIndex)
    {
        Debug.Log("In ToCameraTransition method");
        Debug.Log("Transitioning to camera view for planet index: " + planetIndex);
        allItems = itemmanager.getAllItems();
        List<Planet.item> planetItem = allItems[planetIndex];

        foreach (Planet.item item in planetItem) {
            Debug.Log(item.itemCost);
            Debug.Log(item.itemID);
        }


        //Move Scenes
        SceneManager.LoadScene("Camera Screen");
    }

    public void ToMapTransition(bool picTaken, int Score)
    {
        //Move Scenes
        SceneManager.LoadScene("Map");
    }
}
