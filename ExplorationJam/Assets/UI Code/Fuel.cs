using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public float CurrentTime = 5;
    public float MaxTime = 5;

    public Image FuelImage;

    void Start()
    {
        setFuelAMT();
    } 


    private void Update()
    {
        UpdatedUI();
    }
    public void UpdatedUI()
    {
        FuelImage.fillAmount = resourceTracker.Instance.getFuelAmount() / MaxTime;
        Debug.Log("Fuel Amount: " + resourceTracker.Instance.getFuelAmount());
    }

    private void setFuelAMT()
    {
        MaxTime = resourceTracker.Instance.getMaxFuelAmount();
        CurrentTime = resourceTracker.Instance.getFuelAmount();
    }

}
