using UnityEngine;
using UnityEngine.UI;

public class showHighDemand : MonoBehaviour
{
    [SerializeField] GameObject[] highDemandItems = new GameObject[5];
    [SerializeField] GameObject[] mediumDemandItems = new GameObject[5];
    [SerializeField] GameObject[] lowDemandItems = new GameObject[5];
    [SerializeField] Button showButton;

    void Start()
    {
        if (resourceTracker.Instance == null)
        {
            Debug.LogError("resourceTracker.Instance is NULL");
            return;
        }

        // we want to grab the top three items from resource tracker, this will tell us what to display at the top of the screen
        Debug.Log("Highest Item ID: " + resourceTracker.Instance.getHighestItemID());
        Debug.Log("Medium Item ID: " + resourceTracker.Instance.getMediumItemID());
        Debug.Log("Lowest Item ID: " + resourceTracker.Instance.getLowestItemID());
        for (int i = 0; i < highDemandItems.Length; i++)
        {
            highDemandItems[i].SetActive(false);
        }
        for (int i = 0; i < mediumDemandItems.Length; i++)
        {
            mediumDemandItems[i].SetActive(false);
        }
        for (int i = 0; i < lowDemandItems.Length; i++)
        {
            lowDemandItems[i].SetActive(false);
        }

        if (showButton != null)
        {
            showButton.onClick.AddListener(buttonClicked);
        }
        else
        {
            Debug.LogError("showButton is NULL");
        }
    }

    void buttonClicked()
    {
        // just to dissapear and show crap
        if (highDemandItems[resourceTracker.Instance.getHighestItemID()].activeSelf)
        {
            highDemandItems[resourceTracker.Instance.getHighestItemID()].SetActive(false);
        }
        else
        {
            highDemandItems[resourceTracker.Instance.getHighestItemID()].SetActive(true);
        }

        if (mediumDemandItems[resourceTracker.Instance.getMediumItemID()].activeSelf)
        {
            mediumDemandItems[resourceTracker.Instance.getMediumItemID()].SetActive(false);
        }
        else
        {
            mediumDemandItems[resourceTracker.Instance.getMediumItemID()].SetActive(true);
        }

        if (lowDemandItems[resourceTracker.Instance.getLowestItemID()].activeSelf)
        {
            lowDemandItems[resourceTracker.Instance.getLowestItemID()].SetActive(false);
        }
        else
        {
            lowDemandItems[resourceTracker.Instance.getLowestItemID()].SetActive(true);
        }
    }
}
