using UnityEngine;
using UnityEngine.UI;

public class showHighDemand : MonoBehaviour
{
    [SerializeField] GameObject[] highDemandItems = new GameObject[5];
    [SerializeField] GameObject[] mediumDemandItems = new GameObject[5];
    [SerializeField] GameObject[] lowDemandItems = new GameObject[5];
    [SerializeField] Button showButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (resourceTracker.Instance == null)
        {
            Debug.LogError("resourceTracker.Instance is NULL");
            return;
        }
        Transitions.Instance.ToCameraTransition(0);
        Debug.Log("Highest Item ID: " + resourceTracker.Instance.getHighestItemID());
        Debug.Log("Medium Item ID: " + resourceTracker.Instance.getMediumItemID());
        Debug.Log("Lowest Item ID: " + resourceTracker.Instance.getLowestItemID());
        for (int i = 0; i < highDemandItems.Length; i++)
        {
            // if (i == resourceTracker.Instance.getHighestItemID())
            // {
            //     highDemandItems[i].SetActive(true);
            // }
            // else
            // {
            //     highDemandItems[i].SetActive(false);
            // }
            highDemandItems[i].SetActive(false);
        }
        for (int i = 0; i < mediumDemandItems.Length; i++)
        {
            // if (i == resourceTracker.Instance.getMediumItemID())
            // {
            //     mediumDemandItems[i].SetActive(true);
            // }
            // else
            // {
            //     mediumDemandItems[i].SetActive(false);
            // }
            mediumDemandItems[i].SetActive(false);
        }
        for (int i = 0; i < lowDemandItems.Length; i++)
        {
            // if (i == resourceTracker.Instance.getLowestItemID())
            // {
            //     lowDemandItems[i].SetActive(true);
            // }
            // else
            // {
            //     lowDemandItems[i].SetActive(false);
            // }
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
