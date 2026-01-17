using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public float CurrentTime = 5;
    public float MaxTime = 5;

    public Image FuelImage;


    private void Update()
    {
        UpdatedUI();
    }
    public void UpdatedUI()
    {
        FuelImage.fillAmount = CurrentTime / MaxTime;
    }
}
