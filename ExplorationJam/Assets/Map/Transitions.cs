using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public static Transitions Instance { get; private set; }
    [SerializeField] public itemManager itemmanager;
    [SerializeField] List<List<Planet.item>> allItems;
    private resourceTracker resourceTracker;    
    void Awake()
    {
        resourceTracker = Object.FindFirstObjectByType<resourceTracker>();
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

    public List<Planet.item> ToCameraTransition(int planetIndex)
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

        return planetItem;
    }

    public void ToMapAfterPicture(int Score)
    {

        resourceTracker.addCash(Score);
        //Move Scenes
        SceneManager.LoadScene("Map");
    }

    public void ToMapTransition()
    {
        //Move Scenes
        SceneManager.LoadScene("Map");
    }
}
