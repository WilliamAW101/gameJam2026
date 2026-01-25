using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public static Transitions Instance { get; private set; }
    [SerializeField] public itemManager itemmanager;
    [SerializeField] List<List<Planet.item>> allItems;
    private resourceTracker resourceTracker;  
    private int planetIndex = -1;  
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
        PlanetManager.Instance.hideEverything();
        SceneManager.LoadScene("Camera Screen");

        return planetItem;
    }

    public void ToMapAfterPicture(int Score)
    {

        resourceTracker.addCash(Score);
        //Move Scenes
        PlanetManager.Instance.showEverything();
        SceneManager.LoadScene("Map");
    }

    public void ToMapTransition()
    {
        //Move Scenes
        PlanetManager.Instance.showEverything();
        SceneManager.LoadScene("Map");
    }

    public int getPlanetIndex()
    {
        return planetIndex;
    }

    public void setPlanetIndex(int index)
    {
        planetIndex = index;
    }
}
